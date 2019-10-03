using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{

    public GameObject Player;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1f) {
            
            GetComponent<Animator>().enabled = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}
