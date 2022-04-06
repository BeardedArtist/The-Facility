using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // apply a speed to mouse movement.

    float xRotation = 0f;

    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // hide and lock cursor.
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // get preprogrammed input for mouse on x-axis.
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // get preprogrammed input for mouse on x-axis.

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // limit player camera movement for up and down. 

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX); // allows for players to look left/right w/mouse.
    }
}
