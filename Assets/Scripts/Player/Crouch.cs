using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public CharacterController characterController;

    // TESTING NEW CROUCHING METHOD
    [SerializeField] private Transform mainCameraTransform = null;
    [SerializeField] private float crouchSpeed = 0.3f;
    [SerializeField] private float standHeight = 2.0f;
    [SerializeField] private float crouchHeight = 1.0f;

    private bool _crouching;
    // TESTING NEW CROUCHING METHOD

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _crouching = Input.GetKey(KeyCode.LeftControl);

        // ORIGINAL CODE BELOW
        // if(Input.GetKey(KeyCode.LeftControl))
        // {
        //     // ORIGINAL CODE
        //     //characterController.height = 0.1f;

        //     //TEST

        //     //TEST
        // }
        // else
        // {
        //     // ORIGINAL CODE
        //     //characterController.height = 2f;

        //     //TEST
        //     //TEST
        // }
    }

    // CODE WORKS GREAT! But there is a bug with jumping.
    private void FixedUpdate() 
    {
        var desiredHeight = _crouching ? crouchHeight : standHeight;

        if (characterController.height != desiredHeight)
        {
            AdjustHeight(desiredHeight);

            var camPos = mainCameraTransform.transform.position;
            camPos.y = characterController.height;

            mainCameraTransform.transform.position = camPos;
        }
    }

    private void AdjustHeight(float height)
    {
        float center = height / 2;

        characterController.height = Mathf.Lerp(characterController.height, height, crouchSpeed);
        characterController.center = Vector3.Lerp(characterController.center, new Vector3(0, center, 0), crouchSpeed);
    }
}
