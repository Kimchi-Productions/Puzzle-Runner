using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    public GameObject Player;
    public float gravityAfterCollision = -1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.GetComponent<Rigidbody2D>().gravityScale = gravityAfterCollision;

    }

}

