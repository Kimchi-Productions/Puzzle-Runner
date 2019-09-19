using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speedX = -1;
    public GameObject gameoverui;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector2(speedX, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameoverui.SetActive(true);
            Time.timeScale = 0f;
        }

        if (collision.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
        }
    }
}
