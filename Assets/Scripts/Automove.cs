using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automove : MonoBehaviour
{
    [Range(-5, 5)]
    public float Speed_X;
    [Range(-5, 5)]
    public float Speed_Y;



    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Destroy(this.gameObject);
    //    Destroy(other.gameObject);
    //    Debug.Log("Destroyed due to collision");
    //}


    //void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //    Debug.Log("Destroyed due to despawning");
    //}
    public Inventory inventory;

    void Update()
    {
        this.transform.Translate(new Vector2(Speed_X, Speed_Y) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IInventoryItem item = collision.collider.GetComponent<IInventoryItem>();
        if(item != null && collision.gameObject.tag == "CanPickUp")
        {
            Debug.Log(item);
            inventory.AddItem(item);
        }
    }
}
