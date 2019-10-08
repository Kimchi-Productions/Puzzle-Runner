﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, IInventoryItem
{
    public GameObject portalOut;
    public GameObject player;
    

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

        
        if (gameObject.tag == "CanPickUp")
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
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5.8f,3.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = Image;
        gameObject.GetComponent<Transform>().Rotate(new Vector3( 0, 0, 90 ));
        gameObject.SetActive(true);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        Vector3 pz = spawnPos;
        pz.z = 0;
        gameObject.transform.position = pz;
        GameObject.Find("Inventory").GetComponent<Inventory>().RemoveItem(this);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && gameObject.tag == "CantPickUp")
        {
            gameObject.GetComponent<AudioSource>().Play();
            player.transform.position = new Vector2(portalOut.transform.position.x, portalOut.transform.position.y);
        }else{
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
