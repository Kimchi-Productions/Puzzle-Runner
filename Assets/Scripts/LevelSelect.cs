﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelSelect : MonoBehaviour
{
    public GameObject preFabButton;
    public Button button;
    public GameObject Buttons;  
    public Image[] showStars;
    public int counter = 1;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        SaveSystem.LoadStar();
        
        for (int i = 0; i <= SceneManager.sceneCountInBuildSettings - 3; i++)
        {
            
            if (i > 0)
            {
                counter++;
            }
            
            string levelName = "Level-" + counter;
            Buttons = Instantiate(preFabButton, transform);
            Buttons.GetComponentInChildren<Text>().text = "" + counter;
            showStars = Buttons.GetComponentsInChildren<Image>();
            Button buttonElement = Buttons.GetComponent<Button>();
            buttonElement.onClick.AddListener(() => GoToLevel(levelName));

            switch (StarManagement.starList[i].amountOfStars)
            {
                case 1:
                    showStars[1].color = new Color32(255, 255, 225, 255);
                    Debug.Log("1 Sterren");
                    break;
                case 2:
                    showStars[1].color = new Color32(255, 255, 225, 255);
                    showStars[2].color = new Color32(255, 255, 225, 255);
                    Debug.Log("2 Sterren");
                    break;
                case 3:
                    showStars[1].color = new Color32(255, 255, 225, 255);
                    showStars[2].color = new Color32(255, 255, 225, 255);
                    showStars[3].color = new Color32(255, 255, 225, 255);
                    Debug.Log("3 Sterren");
                    break;
            }

            if (i + 1 > levelAt)
            {
                buttonElement.interactable = false;
                buttonElement.GetComponent<Image>().color = new Color32(0, 0, 20, 255);
            }
        }
    }

    public void GoToLevel(string fileName)
    {
        SceneManager.LoadScene(fileName);
    }
}
