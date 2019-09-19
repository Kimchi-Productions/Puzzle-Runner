using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portalOut;
    public GameObject player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.position = new Vector2(portalOut.transform.position.x, portalOut.transform.position.y);
        }
    }
}
