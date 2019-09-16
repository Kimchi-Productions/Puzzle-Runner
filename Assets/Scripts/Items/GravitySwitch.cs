using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour, IInventoryItem
{
    public string _Name;
    public string Name
    {
        get
        {
            return _Name;
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickUp()
    {
        if (gameObject.tag == "CanPickUp")
        {
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void OnDrop()
    {
        gameObject.tag = "CantPickUp";
        gameObject.SetActive(true);
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
    }

    public float gravityAfterCollision = -1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && gameObject.tag == "CantPickUp")
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Player.GetComponent<Rigidbody2D>().gravityScale = gravityAfterCollision;
        }

    }

}

