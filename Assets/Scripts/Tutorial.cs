using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private bool hasStarted = false;
    void Start()
    {
    }

    void Update()
    {
        if (!hasStarted)
        {
            Time.timeScale = 0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            Time.timeScale = 1f;
        }
    }
}
