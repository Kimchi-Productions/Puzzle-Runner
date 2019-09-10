using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTestItem : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "InventoryTestItem";
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
        gameObject.SetActive(false);
    }

    public void OnDrop()
    {
        gameObject.SetActive(true);
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
    }
}
