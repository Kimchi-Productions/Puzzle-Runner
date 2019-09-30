using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishui;
    public int getActiveLevel;
    public int addedStars;

    public void start(){
        Time.timeScale = 1f;
        finishui.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f;
        finishui.SetActive(true);
        getActiveLevel = SceneManager.GetActiveScene().buildIndex - 2;

        if (ItemStar.starPickedUp == false)
        {
            addedStars = 2;
            earnedStars(getActiveLevel, addedStars);
            StarManagement.addStar(getActiveLevel, addedStars);
        }
        else
        {
            addedStars = 3;
            earnedStars(getActiveLevel, addedStars);
            StarManagement.addStar(getActiveLevel, addedStars);
            ItemStar.starPickedUp = false;
        }
    }

    public void earnedStars(int s, int a)
    {
        SaveSystem.LoadStar();

        if (addedStars > StarManagement.starList[getActiveLevel].amountOfStars)
        {
            Debug.Log("New HIGHSCORE! You have earned: " + addedStars + " stars");
            Debug.Log("Your best score for this level was: " + StarManagement.starList[getActiveLevel].amountOfStars + " stars");
        }
        else
        {
            Debug.Log("NO new HIGHSCORE.. You have earned: " + addedStars + " stars");
            Debug.Log("Your best score for this level was: " + StarManagement.starList[getActiveLevel].amountOfStars + " stars");
        }
    }
}
    