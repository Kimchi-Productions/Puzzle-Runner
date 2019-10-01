using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemStar : MonoBehaviour
{
    private GameObject finish;
    private void Start()
    {
        finish = GameObject.FindGameObjectWithTag("Finish");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        finish.GetComponent<FinishMenu>().pickedUpStars ++;
    }
}
