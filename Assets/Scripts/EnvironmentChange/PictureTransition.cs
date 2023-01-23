using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureTransition : MonoBehaviour
{
    // Object References
    [SerializeField] private GameObject PictureUI;
    [SerializeField] private GameObject player;

    // Bool References
    private bool trig;
    private bool isPictureSeen = false;

    // Script References
    [SerializeField] private MouseLook mouseLook_Script;
    [SerializeField] private PlayerMovement playerMovement_Script;
    [SerializeField] private Blink blink_Script;
    private CharacterController characterController_Script;

    // Transform Reference
    public Transform warpTarget;

    // Player Collider Reference
    [SerializeField] private Collider other;

    // Animator Reference
    [SerializeField] private Animator blink_Anim;
    [SerializeField] private Animator blink_Anim_2;

    private void Start() 
    {
        characterController_Script = player.GetComponent<CharacterController>();    
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
            // Add Interact UI
        }  
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        // Disable Interact UI    
    }


    private void Update() 
    {
        if (trig == true && isPictureSeen == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PictureUI.SetActive(true);
                mouseLook_Script.mouseSensitivity = 0;
                playerMovement_Script.enabled = false;
                isPictureSeen = true;
            }
        }

        else if (trig == true && isPictureSeen == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (blink_Script.isBlinking == false)
                {
                    blink_Anim.Play("TopLidBlink", 0, 0.25f);
                    blink_Anim_2.Play("BottomLidBlink", 0, 0.25f);
                    StartCoroutine(TransitionAfterBlink());
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Transitions/Transition_Jing", GetComponent<Transform>().position);

                    // PictureUI.SetActive(false);
                    // mouseLook_Script.mouseSensitivity = 3;
                    // playerMovement_Script.enabled = true;
                    // isPictureSeen = false;

                    // // TEST TELEPORT
                    // characterController_Script.enabled = false;
                    // player.transform.position = warpTarget.transform.position;
                    // player.transform.rotation = warpTarget.transform.rotation;
                    // characterController_Script.enabled = true;
                }
                

                // Vector3 offsetPosition = other.transform.position - transform.position;
                // other.transform.position = warpTarget.position + offsetPosition;
            }
        }   
    }

    IEnumerator TransitionAfterBlink()
    {
        yield return new WaitForSeconds(0.40f);
        PictureUI.SetActive(false);
        mouseLook_Script.mouseSensitivity = 3;
        playerMovement_Script.enabled = true;
        isPictureSeen = false;

        // TEST TELEPORT
        characterController_Script.enabled = false;
        player.transform.position = warpTarget.transform.position;
        player.transform.rotation = warpTarget.transform.rotation;
        characterController_Script.enabled = true;
        
    }


}
