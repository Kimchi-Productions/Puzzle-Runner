using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    public float timer;
    public int timeBetweenShooting = 2;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenShooting)
        {
            Instantiate(projectile, this.transform.position, Quaternion.identity);
            timer = 0;
        }

    }
}
