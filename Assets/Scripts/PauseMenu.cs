using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;

    public void Pause () {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume () {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
