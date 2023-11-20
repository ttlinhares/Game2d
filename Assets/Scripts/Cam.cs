using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 

    void LateUpdate()
    {
        if (target != null)
        {
            // Obt�m a posi��o atual da c�mera
            Vector3 currentPosition = transform.position;

            
            float newYPosition = Mathf.Lerp(currentPosition.y, target.position.y, smoothSpeed);

            
            transform.position = new Vector3(currentPosition.x, newYPosition, currentPosition.z);
        }
    }
}