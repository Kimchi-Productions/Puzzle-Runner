using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;
    public GameObject[] startItems;

    private void Start()
    {
        Inventory.ItemAdded += Inventory_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;

        foreach (GameObject item in startItems)
        {
            Debug.Log(item.GetComponent<IInventoryItem>());
            GameObject newItem = Instantiate(item, new Vector3(0, 0, -10), Quaternion.identity);
            Inventory.AddItem(newItem.GetComponent<IInventoryItem>());
        }
}

    public Transform inventoryPanel;

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e)
    {
        Debug.Log("Item Added to HUD");
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
