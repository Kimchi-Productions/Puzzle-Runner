using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    private void Start()
    {
        Inventory.ItemAdded += Inventory_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    public Transform inventoryPanel;

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e)
    {
        foreach (Transform Slot in inventoryPanel)
        {
            Image image = Slot.GetChild(0).GetComponent<Image>();
            ItemDragHandler itemDragHandler = Slot.GetChild(0).GetComponent<ItemDragHandler>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        foreach (Transform Slot in inventoryPanel)
        {
            Image image = Slot.GetChild(0).GetComponent<Image>();
            ItemDragHandler itemDragHandler = Slot.GetChild(0).GetComponent<ItemDragHandler>();

            if (itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;

                break;
            }
        }
    }
}
