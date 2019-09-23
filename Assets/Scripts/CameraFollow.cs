using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject targetObject;
    private float distanceToTarget;

    // Start is called before the first frame update
    void Start()
    {
        distanceToTarget = transform.position.x - targetObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float targetObjectX = targetObject.transform.position.x;
        float targetObjectY = targetObject.transform.position.y;
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + distanceToTarget - 1;
        newCameraPosition.y = targetObjectY + distanceToTarget - 3.5f;
        transform.position = newCameraPosition;

    }
}
