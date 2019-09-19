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
        //Spawn radial menu for items in the item array, change to existing inventory system?

        for (int i = 0; i < mItems.Count; i++)
        {
            //Spawn button
            radialbutton newButton = Instantiate(buttonPrefab) as radialbutton;
            newButton.transform.SetParent(newMenu.transform, false);
            float theta = ( 2* Mathf.PI / mItems.Count) *i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector2 (xPos, yPos)* 70f;
            newButton.circle.color = mItems[i].Color;
            newButton.icon.sprite = mItems[i].Image;
            newButton.title = mItems[i].Name;
            newButton.inventoryItem = mItems[i];
        }
    }

    void Update()
    {
        //TODO when no item selected, do nothing
        if (Input.GetMouseButtonUp(0) && this.Selected != null)
        {
            Debug.Log(Selected.title);
            Debug.Log(clickPosition);
            Selected.inventoryItem.OnDrop(clickPosition);
            Destroy(menuInstance.gameObject);
            this.Selected = null;
        }
    }

    public void AddItem(IInventoryItem item)
    {
        if(mItems.Count < SLOTS)
        {
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider.enabled)
            {
                collider.enabled = false;

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
            item.OnDrop(clickPosition);

            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();

            if(collider != null)
            {
                collider.enabled = true;
            }

            if(ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }
        }
    }
}
