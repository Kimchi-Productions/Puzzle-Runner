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
        if (gameObject.tag == "CanPickUp")
        {
            gameObject.SetActive(false);
        }
        else
        {
            return;
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

    public void OnDrop(Vector3 spawnPos)
    {
        gameObject.tag = "CantPickUp";
        gameObject.GetComponent<SpriteRenderer>().sprite = Image;
        gameObject.SetActive(true);
        Vector3 pz = spawnPos;
        pz.z = 0;
        gameObject.transform.position = pz;
        GameObject.Find("Inventory").GetComponent<Inventory>().RemoveItem(this);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "CantPickUp")
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            gameObject.GetComponent<AudioSource>().Play();
            Player.GetComponent<Rigidbody2D>().gravityScale = -Player.GetComponent<Rigidbody2D>().gravityScale;
            Player.transform.Rotate(900, 0, 0);
        }else{
            collision.gameObject.GetComponent<AudioSource>().Play();
        }

    }

}

