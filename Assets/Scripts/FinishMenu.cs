using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishui;

    public void start(){
        Time.timeScale = 1f;
        finishui.SetActive(false);
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f;
        finishui.SetActive(true);
        
    }
}
