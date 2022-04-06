using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // get movement input for WASD on horizontal axis.
        float z = Input.GetAxis("Vertical"); // get movement input for WASD on vertical axis.

        //Take above inputs and turn them into a moveable direction.
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime); // takes the move variable and instantiates it in the player controller.


        velocity.y += gravity * Time.deltaTime; // applies gravity and velocity to player.
        controller.Move(velocity * Time.deltaTime); // apply velocity to player controller

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded) // allows for player to jump
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }
    }
}
