using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;
    private bool isSprinting => canSprint && Input.GetKey(sprintKey) && !isCrouching; // Checks if canSprint is TRUE && sprintKey is pressed
    private bool shouldJump => Input.GetKeyDown(jumpKey) && characterController.isGrounded; // Checks if jumpKey is pressed && character is grounded
    private bool shouldCrouch => Input.GetKeyDown(crouchKey) && !duringCrouchAnimation && characterController.isGrounded;
    // => is called Lambda 


    [Header("Functional Options")]
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canCrouch = true;
    [SerializeField] private bool canUseHeadbob = true;
    [SerializeField] private bool useFootsteps = true;


    [Header("Controls")]
    // KeyCode variable allows us to choose a key in inspector
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift; 
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode crouchKey = KeyCode.LeftControl;


    [Header("Movement Parameters")] 
    [SerializeField] public float walkSpeed = 3.0f;
    [SerializeField] public float sprintSpeed = 6.0f;


    [Header("Jumping Parameters")]
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float gravity = 30.0f;


    [Header("Crouch Parameters")]
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private float crouchSpeed = 1.5f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3 (0, 0.5f, 0);
    [SerializeField] private Vector3 standingCenter = new Vector3 (0, 0, 0);
    private bool isCrouching;
    private bool duringCrouchAnimation;

    [Header("Headbob Parameters")]
    [SerializeField] private float walkBobSpeed = 14f;
    [SerializeField] private float walkBobAmount = 0.05f;
    [SerializeField] private float sprintBobSpeed = 18f;
    [SerializeField] private float sprintBobAmount = 0.11f;
    [SerializeField] private float crouchBobSpeed = 8f;
    [SerializeField] private float crouchBobAmount = 0.025f;
    private float defaultYPos = 0;
    private float timer;

    [Header("Footstep Parameters")]
    [SerializeField] private float baseStepSpeed = 0.5f;
    [SerializeField] private float crouchStepMultiplier = 1.5f;
    [SerializeField] private float sprintStepMultiplier = 0.6f;
    [SerializeField] EventReference woodFootsteps = default;
    [SerializeField] EventReference TileFootsteps = default;
    [SerializeField] EventReference ventFootsteps = default;
    [SerializeField] EventReference wetFootsteps = default;
    [SerializeField] EventReference carpetFootsteps = default;
    private float footstepTimer = 0;
    private float getCurrentOffset => isCrouching ? baseStepSpeed * crouchStepMultiplier : isSprinting ? baseStepSpeed * sprintStepMultiplier : baseStepSpeed;

    //[SerializeField] private AudioSource footstepAudioSource; 
    // I may need to use Unity's audio for the footsteps. However, I'll try with FMOD first.


    // TESTING CHECKPOINT SYSTEM ---------------------------------------------
    [SerializeField] private GameObject player;
    // TESTING CHECKPOINT SYSTEM ---------------------------------------------



    private CharacterController characterController;
    public GameObject playerCamera;
    private MouseLook mouseLook; // TEST

    private Vector3 moveDirection;
    private Vector2 currentInput;


    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();
        mouseLook = GetComponent<MouseLook>(); // TEST
        defaultYPos = playerCamera.transform.localPosition.y;



        Cursor.lockState = CursorLockMode.Locked; // THIS MAY CAUSE ISSUES WITH CURRENT IMPLEMENTATION
        Cursor.visible = false; // MAY CAUSE ISSUES
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HandleDeath();
        }


        if (CanMove)
        {
            HandleMovementInput();
            
            if (canJump)
            {
                HandleJump();
            }

            if (canCrouch)
            {
                HandleCrouch();
            }

            if (canUseHeadbob)
            {
                HandleHeadbob();
            }

            if (useFootsteps)
            {
                HandleFootsteps();
            }

            ApplyFinalMovements();
        }
    }

    private void HandleMovementInput()
    {
        //currentInput = new Vector2((isSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical"), (isSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal")); // Gets our front & back movement -- Gets our left & right movements
        currentInput = new Vector2((isSprinting ? sprintSpeed : isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Vertical"), (isSprinting ? sprintSpeed : isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Horizontal")); // Gets our front & back movement -- Gets our left & right movements

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleJump()
    {
        if (shouldJump)
        {
            moveDirection.y = jumpForce;
        }
    }

    private void HandleCrouch()
    {
        if (shouldCrouch)
        {
            StartCoroutine(CrouchStand());
        }
    }

    private void HandleHeadbob()
    {
        if (!characterController.isGrounded)
        {
            return;
        }

        if(Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            timer += Time.deltaTime * (isCrouching ? crouchBobSpeed : isSprinting ? sprintBobSpeed : walkBobSpeed);
            // In Parenthesis --> (If isCrouching == true then use crouchBobSpeed. Else if isSprinting == true then use sprintBobSpeed
            // Else use walkBobSpeed by default)

            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defaultYPos + Mathf.Sin(timer) * (isCrouching ? crouchBobAmount : isSprinting ? sprintBobAmount : walkBobAmount),
                playerCamera.transform.localPosition.z);
        }
    }

    private void HandleFootsteps()
    {
        if (!characterController.isGrounded)
        {
            return;
        }
        
        if (currentInput == Vector2.zero)
        {
            return;
        }

        footstepTimer -= Time.deltaTime;

        if (footstepTimer <= 0)
        {
            if (Physics.Raycast(playerCamera.transform.position, Vector3.down, out RaycastHit hit, 5))
            {
                switch(hit.collider.tag)
                {
                    case "Wood":
                        FMODUnity.RuntimeManager.PlayOneShot(woodFootsteps);
                        break;
                    case "Tile":
                        FMODUnity.RuntimeManager.PlayOneShot(TileFootsteps);
                        break;
                    case "Wet":
                        FMODUnity.RuntimeManager.PlayOneShot(wetFootsteps);
                        break;
                    case "Vent":
                        FMODUnity.RuntimeManager.PlayOneShot(ventFootsteps);
                        break;
                    case "Carpet":
                        FMODUnity.RuntimeManager.PlayOneShot(carpetFootsteps);
                        break;
                    default:
                        FMODUnity.RuntimeManager.PlayOneShot(woodFootsteps);
                        break;
                }
            }
            footstepTimer = getCurrentOffset;
        }
    }

    public void HandleDeath()
    {
        characterController.enabled = false;
        player.transform.position = CheckPoint.GetActiveCheckPointPosition();
        characterController.enabled = true;
    }

    private void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }



    IEnumerator CrouchStand()
    {
        if (isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f)) // Checks to see if anything is above player
        {
            yield break;
        }

        duringCrouchAnimation = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standingHeight : crouchHeight;
        float currentHeight = characterController.height;
        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = characterController.center;

        while (timeElapsed < timeToCrouch)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / timeToCrouch);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed / timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        characterController.height = targetHeight;
        characterController.center = targetCenter;

        isCrouching = !isCrouching;

        duringCrouchAnimation = false;
    }
}
