using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScene_FINAL : MonoBehaviour
{
    // Script References
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] MouseLook mouseLook;

    // bool Reference
    [SerializeField] private bool trig;
    [SerializeField] private bool isAnimationPlaying = false;

    // Animator Reference
    [SerializeField] Animator animator;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            trig = true;
        }
    }

    private void Update() 
    {
        if (trig)
        {
            animator.enabled = true;
            animator.SetBool("FinalChaseSceneAnimTrigger", true);
            isAnimationPlaying = true;
        }    

        if (isAnimationPlaying == true)
        {
            playerMovement.enabled = false;
            mouseLook.enabled = false;
        }

        else
        {
            isAnimationPlaying = false;
            animator.enabled = false;
            playerMovement.enabled = true;
            mouseLook.enabled = true;
            trig = false;
        }
    }
}
