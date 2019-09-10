using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverui;
    // Start is called before the first frame update
    void Start()
    {
        gameoverui.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f;
        gameoverui.SetActive(true);
    }
}
