using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded == true && controller.velocity.magnitude < 2f && !audioSource.isPlaying)
        {
            if (Input.GetKey(KeyCode.W))
            {
                audioSource.volume = Random.Range(0.3f, 0.5f);
                audioSource.pitch = Random.Range(0.8f, 1.1f);
                audioSource.Play();
            }
        }
    }
}
