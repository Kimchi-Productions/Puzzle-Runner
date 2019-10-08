using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioscript : MonoBehaviour
{
    public bool audioPlaying;
    public Button audioToggle;
    public Sprite audioOn, audioOff;

    void Awake ()
     {
         GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
         GameObject[] obj = GameObject.FindGameObjectsWithTag("ButtonAudio");
         if (objs.Length > 1 || obj.Length > 1)
             Destroy(this.gameObject);
  
         DontDestroyOnLoad(this.gameObject);
  
     }
    // Start is called before the first frame update
    void Start()
    {
        audioPlaying = true;
        //audioOn = Resources.Load<Sprite>("sound_on_button");
        //audioOff = Resources.Load<Sprite>("sound_off_button");

        audioToggle.GetComponent<Image>().sprite = audioOff;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggle()
    {
        if(audioPlaying == true)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            audioToggle.GetComponent<Image>().sprite = audioOn;
            audioPlaying = false;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
            audioToggle.GetComponent<Image>().sprite = audioOff;
            audioPlaying = true;
        }
        
    }

    //public void startPlaying()
    //{
    //    gameObject.GetComponent<AudioSource>().Play();
    //}
}
