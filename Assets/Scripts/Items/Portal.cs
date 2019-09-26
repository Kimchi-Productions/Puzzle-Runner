using System.Collections;
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
            player.transform.position = new Vector2(portalOut.transform.position.x, portalOut.transform.position.y);
        }
    }
}
