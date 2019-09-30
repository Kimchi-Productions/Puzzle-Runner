using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IInventoryItem
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
            return transform;
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

    public float timer;
    public int timeToDetonate = 2;
    public bool detonated = false;
    public GameObject door;

    public void OnDrop(Vector3 spawnPos)
    {
        gameObject.tag = "CantPickUp";
        gameObject.SetActive(true);
        Vector3 pz = spawnPos;
        pz.z = 0;
        gameObject.transform.position = pz;
        GameObject.Find("Inventory").GetComponent<Inventory>().RemoveItem(this);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeToDetonate && detonated == false)
        {
            gameObject.transform.GetComponent<CircleCollider2D>().radius = 1.5f;
            detonated = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == door)
        {
            Destroy(door);
            Destroy(gameObject);
        }
    }

}
