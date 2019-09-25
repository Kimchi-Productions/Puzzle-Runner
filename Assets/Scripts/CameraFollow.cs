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
        newCameraPosition.x = targetObjectX + 4;
        newCameraPosition.y = targetObjectY;
        transform.position = newCameraPosition;

    }
}
