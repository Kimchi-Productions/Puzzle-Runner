﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        Debug.Log("Picked up Star");
    }
}