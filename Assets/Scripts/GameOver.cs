using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverui;
    void Start()
    {
        gameoverui.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            gameoverui.SetActive(true);
        }
        
    }
}
