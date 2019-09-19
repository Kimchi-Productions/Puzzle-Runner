using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour, IInventoryItem
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

    public Color _Color = new Color(1, 1, 1, 1);

    public Color Color
    {
        get
        {
            return _Color;
        }
    }


    public void OnPickUp()
    {
        
        if(gameObject.tag == "CanPickUp")
        {
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void OnDrop(Vector3 spawnPos)
    {
        gameObject.tag = "CantPickUp";
        gameObject.SetActive(true);
        Vector3 pz = spawnPos;
        pz.z = 0;
        gameObject.transform.position = pz;
        GameObject.Find("Inventory").GetComponent<Inventory>().RemoveItem(this);
    }

    public int jumpForceup;
    public int jumpForceforward;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor"){
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "CantPickUp")
        {
            gameObject.GetComponent<Animator>().enabled = true;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForceup);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForceforward);
        }
    }

}
