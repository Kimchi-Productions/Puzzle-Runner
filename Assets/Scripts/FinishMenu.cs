using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishui;
    public int getActiveLevel;
    public int addedStarts;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ItemStar.starPickedUp == false)
        {
            getActiveLevel = SceneManager.GetActiveScene().buildIndex - 2;
            addedStarts = 2;
            StarManagement.addStar(getActiveLevel, addedStarts);
            Time.timeScale = 0f;
            finishui.SetActive(true);
        }
        else
        {
            getActiveLevel = SceneManager.GetActiveScene().buildIndex - 2;
            addedStarts = 3;
            StarManagement.addStar(getActiveLevel, addedStarts);
            Time.timeScale = 0f;
            finishui.SetActive(true);
        }
    }
}
