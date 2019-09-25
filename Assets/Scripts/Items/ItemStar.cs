using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemStar : MonoBehaviour
{
    static public bool starPickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        starPickedUp = true;
        gameObject.SetActive(false);
    }
}
    