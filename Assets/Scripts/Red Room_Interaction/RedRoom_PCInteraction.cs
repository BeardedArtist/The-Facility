using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRoom_PCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject computerUI;
    [SerializeField] private GameObject redRoomInteractUI;
    [SerializeField] private GameObject redRoomText;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;

    private bool trig;
    private bool isViewingComputer = false;


    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
            redRoomInteractUI.SetActive(true);
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        redRoomInteractUI.SetActive(false);    
    }

    private void Update() 
    {
        if (trig == true && isViewingComputer == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                computerUI.SetActive(true);
                redRoomText.SetActive(true);
                playerMovement.enabled = false;
                mouseLook.enabled = false;
                isViewingComputer = true;
            }
        }

        else if (trig == true && isViewingComputer == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                computerUI.SetActive(false);
                redRoomText.SetActive(false);
                playerMovement.enabled = true;
                mouseLook.enabled = true;
                isViewingComputer = false;
            }
        }    
    }
}
