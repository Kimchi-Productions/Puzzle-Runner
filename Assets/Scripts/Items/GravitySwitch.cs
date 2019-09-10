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

    public bool canPickup;
    public void OnPickUp()
    {
        if (canPickup)
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
        canPickup = false;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.SetActive(true);
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
    }

    public GameObject Player;
    public float gravityAfterCollision = -1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.GetComponent<Rigidbody2D>().gravityScale = gravityAfterCollision;

    }

}

