using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHUD : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        Player.GetComponent<Automove>().Speed_X = 0;
        Player.GetComponent<Animator>().enabled = false;
        Vector3 p = transform.position;
        p.z = 0;
        transform.position = p;
    }

    public void StartGame()
    {
        Player.GetComponent<Automove>().Speed_X = 3;
        Player.GetComponent<Animator>().enabled = true;
        gameObject.SetActive(false);
    }
}
