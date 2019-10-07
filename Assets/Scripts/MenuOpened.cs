using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpened : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            Time.timeScale = 0;
        }
    }
}
