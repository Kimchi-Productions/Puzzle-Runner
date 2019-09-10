using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int SLOTS = 3;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event System.EventHandler<InventoryEventArgs> ItemAdded;
    public event System.EventHandler<InventoryEventArgs> ItemRemoved;

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
            item.OnDrop();

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
