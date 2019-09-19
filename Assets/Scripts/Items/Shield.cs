using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IInventoryItem
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

    public GameObject projectile;

    public void OnDrop()
    {
        gameObject.tag = "CantPickUp";
        gameObject.SetActive(true);

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
    }

}
