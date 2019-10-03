using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHUD : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Player.GetComponent<Automove>().Speed_X = 0;
        Player.GetComponent<Animator>().enabled = false;
    }

    public void StartGame()
    {
        Player.GetComponent<Automove>().Speed_X = 3;
        Player.GetComponent<Animator>().enabled = true;
        gameObject.SetActive(false);
    }
}
