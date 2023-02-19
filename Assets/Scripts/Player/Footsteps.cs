using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] AudioSource audioSource;

    [SerializeField] EventReference eventName;
    public string inputSound;
    public bool playerIsMoving;
    public float walkingSpeed;

    private void Update() 
    {
        if (Input.GetAxis ("Vertical") >= 0.02f || Input.GetAxis("Horizontal") >= 0.02f || Input.GetAxis ("Vertical") <= -0.02f || Input.GetAxis ("Horizontal") <= -0.02f)
        {
            playerIsMoving = true;
        }
        else if (Input.GetAxis ("Vertical") <= 0.01f || Input.GetAxis ("Horizontal") >= 0.01f)
        {
            playerIsMoving = false;
        }
    }

    void CallFootsteps()
    {
        if (playerIsMoving == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(eventName);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("CallFootsteps", 0, walkingSpeed);

        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    void onDisable()
    {
        playerIsMoving = false;
    }



    // Update is called once per frame
    // void Update()
    // {
    //     if (controller.isGrounded == true && controller.velocity.magnitude < 2f && !audioSource.isPlaying)
    //     {
    //         if (Input.GetKey(KeyCode.W))
    //         {
    //             FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/FOOTSTEPS/TILERUNNING/TILERUNNING", GetComponent<Transform>().position);
    //             // audioSource.volume = Random.Range(0.3f, 0.5f);
    //             // audioSource.pitch = Random.Range(0.8f, 1.1f);
    //             // audioSource.Play();
    //         }
    //     }
    // }
}
