using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScene_FINAL : MonoBehaviour
{
    // AI Reference
    [SerializeField] private GameObject AI_Chase;
    
    // Script References
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] MouseLook mouseLook;

    // bool Reference
    [SerializeField] private bool trig;
    [SerializeField] private bool isAnimationPlaying = false;

    // Animator Reference
    [SerializeField] private Animator blink_Anim;
    [SerializeField] private Animator blink_Anim_2;
    [SerializeField] private Blink blink_Script;


    // COMMENTED OUT CODE - IMPLEMENT LATER MAYBE -----------------------------------------------

    //Animator Reference
    //This was the animator for the player body (Camera Control Cutscene) -- COMMENTED OUT NOW
    [SerializeField] Animator animator;


    //Testing Moving Player
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerCamera;
    private bool isCameraInPosition = false;
    private bool hasAnimationPlayed = false;

    // COMMENTED OUT CODE - IMPLEMENT LATER MAYBE -----------------------------------------------



    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            trig = true;
            blink_Anim.Play("TopLidBlink", 0, 0.25f);
            blink_Anim_2.Play("BottomLidBlink", 0, 0.25f);
            //HandleFinalScene();
            HandlePlayerCamera();
        }
    }

    void HandleFinalScene()
    {
        StartCoroutine(ActivateFinalScene());
    }

    IEnumerator ActivateFinalScene()
    {
        yield return new WaitForSeconds(0.40f);
        AI_Chase.SetActive(true);

        // Activate New Environment
    }


    void HandlePlayerCamera()
    {
        if (hasAnimationPlayed == false)
        {
            StartCoroutine(PositionPlayerForAnimation());
        }
    }

    IEnumerator PositionPlayerForAnimation()
    {
        yield return new WaitForSeconds(0.40f);
        if (isCameraInPosition == false)
        {
            playerBody.localRotation = Quaternion.Euler(0, 180, 0);
            playerCamera.localRotation = Quaternion.Euler(0, 0, 0);
            isCameraInPosition = true;
        }
        animator.enabled = true;
        animator.SetBool("FinalChaseSceneAnimTrigger", true);
        isAnimationPlaying = true;

        if (isAnimationPlaying == true)
        {
            playerMovement.enabled = false;
            mouseLook.enabled = false;
        }


        yield return new WaitForSeconds(15.5f);

        isAnimationPlaying = false; // don't need this?
        animator.enabled = false;
        playerMovement.enabled = true;
        mouseLook.enabled = true;
        trig = false;

        hasAnimationPlayed = true;
    }
}
