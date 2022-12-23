using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureTransition : MonoBehaviour
{
    // [SerializeField] private GameObject mainCamera;
    // [SerializeField] private GameObject transitionCamera;
    [SerializeField] private GameObject PictureUI;

    // Bool References
    private bool trig;
    private bool isPictureSeen = false;

    // Script References
    [SerializeField] private MouseLook mouseLook_Script;
    [SerializeField] private PlayerMovement playerMovement_Script;

    // Transform Reference
    public Transform warpTarget;

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = true;
            // Add Interact UI

            if (trig == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isPictureSeen == false)
                    {
                        isPictureSeen = true;
                        PictureUI.SetActive(true);
                        mouseLook_Script.mouseSensitivity = 0;
                        playerMovement_Script.enabled = false;

                        Vector3 offset = other.transform.position - transform.position;
                        other.transform.position = warpTarget.position + offset;
                    }
                }
            }

            // else if (isPictureSeen == true)
            // {
            //     if (Input.GetKeyDown(KeyCode.E))
            //     {
            //         isPictureSeen = false;
            //         PictureUI.SetActive(false);
            //         mouseLook_Script.mouseSensitivity = 3;
            //         playerMovement_Script.enabled = true;
            //     }
            // }
        }

        if (trig == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isPictureSeen == true)
                {
                    isPictureSeen = false;
                    PictureUI.SetActive(false);
                    mouseLook_Script.mouseSensitivity = 3;
                    playerMovement_Script.enabled = true;
                }
            }
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        // Disable Interact UI    
    }


}
