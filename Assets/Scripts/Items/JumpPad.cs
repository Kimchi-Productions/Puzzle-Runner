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

    public Rigidbody2D rigidbody
    {
        get
        {
            return this.GetComponent<Rigidbody2D>();
        }
    }

    public Transform transform
    {
        get
        {
            return this.GetComponent<Transform>();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "CantPickUp")
        {
            Debug.Log("collided");
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<AudioSource>().Play();
            
            if (gameObject.GetComponent<Rigidbody2D>().gravityScale > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForceup);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * jumpForceup);
            }

            if(collision.gameObject.GetComponent<Automove>().Speed_X > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * jumpForceforward);

            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * jumpForceforward);

            }
        }
    }

}
