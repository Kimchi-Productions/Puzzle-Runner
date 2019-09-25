using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelSelect : MonoBehaviour
{
    public GameObject preFabButton;
    public Button button;
    public Text ButtonText;
    public int levelAmount = 2;
    public GameObject Buttons;
    public GameObject[] starText;
    public int counter = 1;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        SaveSystem.LoadStar();
        
        for (int i = 0; i <= levelAmount; i++)
        {
            
            if (i > 0)
            {
                counter++;
            }
            
            string levelName = "Level-" + counter;
            Buttons = Instantiate(preFabButton, transform);
            Buttons.GetComponentInChildren<Text>().text = levelName;
            Button buttonElement = Buttons.GetComponent<Button>();
            buttonElement.onClick.AddListener(() => GoToLevel(levelName));
            starText = GameObject.FindGameObjectsWithTag("ShowStars");
            starText[i].GetComponent<Text>().text = "" + StarManagement.starList[i].amountOfStars;
            
            if (i + 1 > levelAt)
            {
               buttonElement.interactable = false;
            }
        }
    }

    public void GoToLevel(string fileName)
    {
        SceneManager.LoadScene(fileName);
    }
}
