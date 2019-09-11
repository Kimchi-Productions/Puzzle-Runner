using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GotoLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void RestartFirstlvl()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Nextlvl()
    {
        SceneManager.LoadScene("GameScene");
    }

}
