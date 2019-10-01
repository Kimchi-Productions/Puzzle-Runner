using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishui;
    public int getActiveLevel;
    public int addedStars = 0;
    public int pickedUpStars = 0;
    public int finishStarAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f;
        finishui.SetActive(true);
        getActiveLevel = SceneManager.GetActiveScene().buildIndex - 2;

        addedStars = addedStars + finishStarAmount;
        for (int i = 0; i < pickedUpStars; i++)
        {
            addedStars ++;
        }

        earnedStars(getActiveLevel, addedStars);
        StarManagement.addStar(getActiveLevel, addedStars);
        addedStars = 0;
        pickedUpStars = 0;
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
    