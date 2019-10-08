using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject targetObject;
 
    void Update()
    {
        float targetObjectX = targetObject.transform.position.x;
        float targetObjectY = targetObject.transform.position.y;
        Vector3 newCameraPosition = transform.position;

        if (targetObject.GetComponent<Automove>().Speed_X > 0)
        {
            newCameraPosition.x = targetObjectX + 4;
        }
        else
        {
            float halfHeight = Camera.main.orthographicSize;
            float halfWidth = Camera.main.aspect * halfHeight;

            newCameraPosition.x = targetObjectX - halfWidth + 2;
        }

        newCameraPosition.y = targetObjectY;
        transform.position = newCameraPosition;
    }
}
