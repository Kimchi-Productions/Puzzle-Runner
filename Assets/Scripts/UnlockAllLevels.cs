using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class UnlockAllLevels : MonoBehaviour
{

    public int counter;
    public bool allLevelsUnlocked;
    public Text allLevelsUnlockedText;
    public Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefs.GetInt("Unlocked") == 1)
        {
            allLevelsUnlockedText.color = new Color32(255, 255, 255, 255);
            StartCoroutine(blink());
        }
        else
        {
            allLevelsUnlockedText.color = new Color32(255, 255, 255, 0);
            resetButton.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlock()
    {

        counter++;

        if (counter == 5 && PlayerPrefs.GetInt("Unlocked") == 0)
        {
            Debug.Log("All levels are unlocked");
            PlayerPrefs.SetInt("Unlocked", (allLevelsUnlocked ? 0 : 1));
            allLevelsUnlockedText.color = new Color32(255, 255, 255, 255);
            StartCoroutine(blink());
            resetButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            counter = 0;
        }


    }

    public void reset()
    {
        if(PlayerPrefs.GetInt("Unlocked") == 1)
        {
            allLevelsUnlockedText.color = new Color32(255, 255, 255, 0);
            PlayerPrefs.SetInt("Unlocked", (allLevelsUnlocked ? 1 : 0));
            resetButton.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
    }

    public IEnumerator blink()
    {
        while (true)
        {
            allLevelsUnlockedText.text = "";
            yield return new WaitForSeconds(.5f);
            allLevelsUnlockedText.text = "ALL LEVELS ARE UNLOCKED!";
            yield return new WaitForSeconds(.5f);
        }
    }
}
