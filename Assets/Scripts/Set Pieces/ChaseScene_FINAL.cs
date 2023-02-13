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


    // Testing Moving Player
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerCamera;
    private bool isCameraInPosition = false;
    [SerializeField] private Animator blink_Anim;
    [SerializeField] private Animator blink_Anim_2;
    [SerializeField] private Blink blink_Script;



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
            if (blink_Script.isBlinking == false)
            {
                blink_Anim.Play("TopLidBlink", 0, 0.25f);
                blink_Anim_2.Play("BottomLidBlink", 0, 0.25f);
                //HandlePlayerCamera();
            }
        }
    }


    void HandlePlayerCamera()
    {      
        StartCoroutine(PositionPlayerForAnimation());
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

        else
        {
            isAnimationPlaying = false; // don't need this?
            animator.enabled = false;
            playerMovement.enabled = true;
            mouseLook.enabled = true;
            trig = false;
        }
    }
}
