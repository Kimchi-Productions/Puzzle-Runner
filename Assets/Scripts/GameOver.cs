using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverui;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //gameObject.GetComponent<AudioSource>().Play();
            Time.timeScale = 0f;
            gameoverui.SetActive(true);
        }
        
    }
}
