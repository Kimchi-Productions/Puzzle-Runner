using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChange : MonoBehaviour
{
    private GameObject Player;
    private GameObject[] Objects;
    private bool isFlipped;

    private void Start()
    {
        Objects = GameObject.FindGameObjectsWithTag("Player");
        Player = Objects[0];
    }
    public void ChangeDirection()
    {
        Player.GetComponent<Automove>().Speed_X = -Player.GetComponent<Automove>().Speed_X;
        isFlipped = Player.GetComponent<SpriteRenderer>().flipX;

        if(isFlipped)
        {
            Player.GetComponent<SpriteRenderer>().flipX = false;
        } else
        {
            Player.GetComponent<SpriteRenderer>().flipX = true;
        }

    }
}
