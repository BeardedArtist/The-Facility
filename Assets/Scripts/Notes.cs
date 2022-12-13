using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Notes : MonoBehaviour
{
    // Game Object References
    [SerializeField] private GameObject noteUI;
    [SerializeField] private GameObject pickUpUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] ObjectsToInteract;

    // Bool References
    private bool trig;
    private bool canBePickedUp = true;
    [SerializeField] private bool isPickedUp = false;

    // Script References
    [SerializeField] private MouseLook mouseLook;
    //[SerializeField] private Hide hideScript;
    //[SerializeField] private FMODSfxAudio fMODSfxAudio;
    [SerializeField] private CharacterController characterController;


    private void Start() 
    {
        characterController = player.GetComponent<CharacterController>();    
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
            pickUpUI.SetActive(true);
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        pickUpUI.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (trig == true && isPickedUp == false)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < ObjectsToInteract.Length; i++)
                {
                    if (ObjectsToInteract[i].name == "Journal")
                    {
                        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Item Interaction/JOURNALOPEN", GetComponent<Transform>().position);
                        noteUI.SetActive(true);
                        characterController.enabled = false;
                        mouseLook.mouseSensitivity = 0;
                        pickUpUI.SetActive(false);
                        isPickedUp = true;
                    }

                    if (ObjectsToInteract[i].name == "Note")
                    {
                        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Item Interaction/Page Grab", GetComponent<Transform>().position);
                        noteUI.SetActive(true);
                        characterController.enabled = false;
                        mouseLook.mouseSensitivity = 0;
                        pickUpUI.SetActive(false);
                        isPickedUp = true;
                    }

                    if (ObjectsToInteract[i].name == "Note_2")
                    {
                        BathroomNotePickUp();
                        //fMODSfxAudio.BathroomNotePickUp_Audio();
                    }
                }
            }
        }

        else if (trig == true && isPickedUp == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                noteUI.SetActive(false);
                characterController.enabled = true;
                mouseLook.enabled = true;
                mouseLook.mouseSensitivity = 3;
                isPickedUp = false;
            }
        }
    }


    public void BathroomNotePickUp()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Item Interaction/Page Grab", GetComponent<Transform>().position);
        noteUI.SetActive(true);
        characterController.enabled = false;
        mouseLook.mouseSensitivity = 0;
        pickUpUI.SetActive(false);
        isPickedUp = true;
    }
}
