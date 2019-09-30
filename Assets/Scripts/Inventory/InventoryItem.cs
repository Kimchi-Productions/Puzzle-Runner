using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }
    Color Color { get; }

    Rigidbody2D rigidbody { get; }

    Transform transform { get; }

    void OnPickUp();

    void OnDrop(Vector3 spawnPos);
}

public class InventoryEventArgs : System.EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}
