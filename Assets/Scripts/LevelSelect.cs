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
    public Sprite lvl1;
    public Sprite lvl2;
    public Sprite lvl3;
   
    void Start()
    {
        Sprite buttonlvlimage = null;
        for (int i = 1; i <= levelAmount; i++)
        {
            if (i == 1)
            {
                buttonlvlimage = lvl1;
            }
            if (i == 2)
            {
                buttonlvlimage = lvl2;
            }
            if (i == 3)
            {
                buttonlvlimage = lvl3;
            }
            string levelName = "Level-" + i;
            Debug.Log(i);
            GameObject Buttons = Instantiate(preFabButton, transform);
            Buttons.GetComponent<Image>().sprite = buttonlvlimage;
            Debug.Log(Buttons.GetComponentInChildren<Text>().text);
            Button buttonElement = Buttons.GetComponent<Button>();
            buttonElement.onClick.AddListener(() => GoToLevel(levelName));
        }
    }

    public void GoToLevel(string fileName)
    {
        SceneManager.LoadScene(fileName);
    }

}
