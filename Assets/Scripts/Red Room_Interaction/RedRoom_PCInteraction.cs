using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class RedRoom_PCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject computerUI;
    [SerializeField] private GameObject redRoomInteractUI;
    [SerializeField] private GameObject redRoomText;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;


    // FMOD Parameters ---------------------------
    [SerializeField] EventReference eventName;
    private static FMOD.Studio.EventInstance redRoomComputerSFX;
    // FMOD Parameters ---------------------------

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
        PlayAudio();

        
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


    private void PlayAudio()
    {
        if (!FMODExtension.IsPlaying(redRoomComputerSFX))
        {
            // redRoomComputerSFX = FMODUnity.RuntimeManager.CreateInstance(eventName);
            // redRoomComputerSFX.start();

            //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/RRCOMPSCREEN", GetComponent<Transform>().position);

        }
    }

    private void StopAudio()
    {
        redRoomComputerSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        redRoomComputerSFX.release();
    }

    private void OnDestroy() 
    {
        redRoomComputerSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        redRoomComputerSFX.release();
    }
}
