using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public int jumpForceup;
    public int jumpForceforward;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForceup);
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * jumpForceforward);
    }
}
