using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public int nextSceneLoaded;

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GotoLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void Nextlvl()
    {
        nextSceneLoaded = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextSceneLoaded + 1);
        if(nextSceneLoaded > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoaded);
        }
    }

}
