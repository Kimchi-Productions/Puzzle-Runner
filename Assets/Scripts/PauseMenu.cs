using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public void start(){
        Time.timeScale = 1f;
    }
    public void Pause () {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume () {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
