using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int jumpForceup;
    public int jumpForceforward;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForceup);
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * jumpForceforward);
    }
}
