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
        // float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // get preprogrammed input for mouse on x-axis.
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // get preprogrammed input for mouse on x-axis.

        // TEST - Trying without Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // get preprogrammed input for mouse on x-axis.
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; // get preprogrammed input for mouse on x-axis.
        // TEST - Trying without Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // limit player camera movement for up and down. 

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX); // allows for players to look left/right w/mouse.
    }

    // float xRotation = 0f;
    // public Vector2 turn;
    // public float sensitivity = 50;
    // public Vector3 deltaMove;
    // public float speed = 1;

    // private void Start() 
    // {
    //     Cursor.lockState = CursorLockMode.Locked;    
    // }

    // private void Update() 
    // {
    //     turn.x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
    //     turn.y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    //     xRotation -= turn.y;
    //     xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    //     transform.localRotation = Quaternion.Euler(xRotation, turn.x, 0);
    // }
}
