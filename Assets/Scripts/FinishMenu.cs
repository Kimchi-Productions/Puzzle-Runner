using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishui;
    public int getActiveLevel;
    public int addedStars = 0;
    public int pickedUpStars = 0;
    public int finishStarAmount = 1;
    public GameObject starContainer;
    public Image[] showStars;
    public Text starText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f;
        gameObject.GetComponent<AudioSource>().Play();
        finishui.SetActive(true);
        getActiveLevel = SceneManager.GetActiveScene().buildIndex - 2;

        addedStars = addedStars + finishStarAmount;
        for (int i = 0; i < pickedUpStars; i++)
        {
            addedStars ++;
        }

        showStars = starContainer.GetComponentsInChildren<Image>();
        starText = starContainer.GetComponentInChildren<Text>();
        earnedStars(getActiveLevel, addedStars);
        StarManagement.addStar(getActiveLevel, addedStars);

        addedStars = 0;
        pickedUpStars = 0;

        ShowStarsInLevel.disableStars();
    }

    public void earnedStars(int s, int a)
    {
        SaveSystem.LoadStar();

        if (addedStars > StarManagement.starList[getActiveLevel].amountOfStars)
        {
            Debug.Log("New HIGHSCORE! You have earned: " + addedStars + " stars");
            Debug.Log("Your best score for this level was: " + StarManagement.starList[getActiveLevel].amountOfStars + " stars");
            starText.text = "NEW HIGHSCORE! YOUR NEW SCORE:";
            showScore(addedStars);
        }
        else
        {
            Debug.Log("NO new HIGHSCORE.. You have earned: " + addedStars + " stars");
            Debug.Log("Your best score for this level was: " + StarManagement.starList[getActiveLevel].amountOfStars + " stars");
            starText.text = "NO NEW HIGHSCORE! YOUR OLD SCORE:";
            showScore(StarManagement.starList[getActiveLevel].amountOfStars);
        }
    }

    public void showScore(int score)
    {
        switch (score)
        {
            case 1:
                showStars[0].color = new Color32(255, 255, 255, 255);
                break;
            case 2:
                showStars[0].color = new Color32(255, 255, 255, 255);
                showStars[1].color = new Color32(255, 255, 255, 255);
                break;
            case 3:
                showStars[0].color = new Color32(255, 255, 255, 255);
                showStars[1].color = new Color32(255, 255, 255, 255);
                showStars[2].color = new Color32(255, 255, 255, 255);
                break;
        }
    }
}
    