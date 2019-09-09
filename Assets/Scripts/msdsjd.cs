using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class msdsjd : MonoBehaviour
{
    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        paused = true;

        if (Time.timeScale == 0)
        {
            paused = false;
        }

        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
