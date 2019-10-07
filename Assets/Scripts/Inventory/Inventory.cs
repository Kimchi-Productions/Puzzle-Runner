using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Class to add and remove items from the inventory system (mItems list)

    public int SLOTS = 3;

    public radialbutton buttonPrefab;
    public radialbutton Selected;
    public GameObject HUD;
    public radialmenu radialmenu;
    private radialmenu menuInstance;
    public Vector3 clickPosition;

    public List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event System.EventHandler<InventoryEventArgs> ItemAdded;
    public event System.EventHandler<InventoryEventArgs> ItemRemoved;

    public void SpawnButtons(radialmenu newMenu)
    {
        menuInstance = newMenu;
        float theta = 0;

        for (int i = 0; i < mItems.Count; i++)
        {
            //Spawn button
            radialbutton newButton = Instantiate(buttonPrefab) as radialbutton;
            newButton.transform.SetParent(newMenu.transform, false);
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector2 (xPos, yPos) * 200f;
            newButton.circle.color = mItems[i].Color;
            newButton.icon.sprite = mItems[i].Image;
            newButton.title = mItems[i].Name;
            newButton.inventoryItem = mItems[i];

            if (i % 2 == 0)
            {
                if(theta < 0)
                {
                    theta = theta - 0.8f;
                } else if (theta >= 0)
                {
                    theta = theta + 0.8f;
                }
            }
            else
            {
                theta = -theta;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && this.Selected != null)
        {
            Selected.inventoryItem.OnDrop(clickPosition);
            Destroy(menuInstance.gameObject);
            this.Selected = null;
            Time.timeScale = 1f;

        }
    }

    public void AddItem(IInventoryItem item)
    {
        if(mItems.Count < SLOTS)
        {
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider.enabled)
            {
                BoxCollider2D boxCollider = (item as MonoBehaviour).GetComponent<BoxCollider2D>();
                collider.enabled = false;
                boxCollider.enabled = false;

                mItems.Add(item);

                item.OnPickUp();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        if(mItems.Remove(item))
        {
            mItems.Remove(item);
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            BoxCollider2D boxCollider = (item as MonoBehaviour).GetComponent<BoxCollider2D>();

            if (collider != null)
            {
                collider.enabled = true;
                boxCollider.enabled = true;
            }

            if(ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }

            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale < 0)
            {
                item.rigidbody.gravityScale = -item.rigidbody.gravityScale;
                item.rigidbody.velocity = new Vector2(0,0);
                Quaternion rotation = Quaternion.Euler(0, 0, 180);
                item.transform.localRotation = rotation;
            }
        }
    }
}
