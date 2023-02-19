using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryPeekScene : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject libraryCamera;
    [SerializeField] private GameObject AI_LibraryScene;
    [SerializeField] private GameObject peakInDoorUI;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private bool isLibraryCameraOn = false;
    private bool trig = false;

    // Referencing Other Scripts ----------------------------------
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private AIController_LibraryScene aIController_LibraryScene;
    [SerializeField] private OpenCloseDoor openCloseDoor;
    [SerializeField] private OpenCloseDoor_LOCKED openCloseDoor_LOCKED;
    // ------------------------------------------------------------


    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
            peakInDoorUI.SetActive(true);
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
        peakInDoorUI.SetActive(false);
    }

    private void Update() 
    {
        if (trig == true)
        {
            // Add UI here

            if (isLibraryCameraOn == false)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    isLibraryCameraOn = true;
                    libraryCamera.SetActive(true);
                    flashLight.SetActive(false);
                    AI_LibraryScene.SetActive(true);
                    mouseLook.mouseSensitivity = 0;
                    Debug.Log("Library Camera Active");
                }
            }

            else if (isLibraryCameraOn == true)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    isLibraryCameraOn = false;
                    libraryCamera.SetActive(false);
                    flashLight.SetActive(true);
                    mouseLook.mouseSensitivity = 3;
                    Debug.Log("Library Camera False");
                }
            }
        }


        if (aIController_LibraryScene.isAIActive == false)
        {
            openCloseDoor_LOCKED.enabled = false;
            openCloseDoor.enabled = true;
        }    
    }
}
