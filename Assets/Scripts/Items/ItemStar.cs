using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemStar : MonoBehaviour
{
    //public StarManagement starManagement;
    static public int getActiveLevel;

    public void Start()
    {
        getActiveLevel = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StarManagement.addStar(getActiveLevel);
        Debug.Log("DIT IS LEVEL: " + getActiveLevel);
        gameObject.SetActive(false);
    }
}
