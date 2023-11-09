using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 2.5f; 
    public float  offset = 6;

    void LateUpdate()
    {
        
        Vector3 desiredPosition = new Vector3(target.position.x + offset, 0, transform.position.z);
   
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
   
        transform.position = smoothedPosition;

       
        //transform.LookAt(target);
    }
}

