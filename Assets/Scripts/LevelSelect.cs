using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelSelect : MonoBehaviour
{
    const string path = "Assets/Scenes/Levels";
    public GameObject preFabButton;
    public Button button;
    public Text ButtonText;
    public int levelAmount;
   
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 1; i <= levelAmount; i++)
        {
            string levelName = "Level-" + i;
            Debug.Log(i);
            GameObject Buttons = Instantiate(preFabButton, transform);
            Buttons.GetComponentInChildren<Text>().text = levelName;
            Debug.Log(Buttons.GetComponentInChildren<Text>().text);
            Button buttonElement = Buttons.GetComponent<Button>();
            buttonElement.onClick.AddListener(() => GoToLevel(levelName));

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
