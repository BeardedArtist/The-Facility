using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToPosition : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.35f;
    private Vector3 velocity = Vector3.zero;

    private void Update() 
    {
        // Define a target position above and behind the target transform.
        Vector3 targetPosition = target.transform.position;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
