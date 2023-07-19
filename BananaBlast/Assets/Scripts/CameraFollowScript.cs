using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null) // if player exists
        {
            Vector3 desiredPosition = target.position + offset; // set camera focus on player
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // smoothen camera movement
            transform.position = smoothedPosition; // set camera position
        }   
    }
}
