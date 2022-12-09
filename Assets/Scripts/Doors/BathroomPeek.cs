using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomPeek : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject stallCamera;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private Animator myBathroomDoor = null;
    [SerializeField] private GameObject openBathroomDoorUI;
    [SerializeField] private Hide hide;
    [SerializeField] private bool isStallCameraOn = false;
    private bool trigger;
    private bool trig;

    // Referecing Other Scripts ---------------------------------------
    [SerializeField] private MouseLook mouseLook;
    // Referecing Other Scripts ---------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        myBathroomDoor = GetComponent<Animator>();

        myBathroomDoor.SetBool("Open", false);
        trigger = false;
    }

    // private void OnTriggerStay(Collider other) 
    // {
    //     if (other.tag == "Flashlight Eyes 2")
    //     {
    //         trig = true;
    //         openBathroomDoorUI.SetActive(true);
    //     }    
    // }

    // private void OnTriggerExit(Collider other) 
    // {
    //     trig = false;
    //     openBathroomDoorUI.SetActive(false);    
    // }

    // Update is called once per frame
    void Update()
    {
        if (hide.isHiding == true)
        {
            trigger = myBathroomDoor.GetBool("Open");
            openBathroomDoorUI.SetActive(true);

            if (isStallCameraOn == false)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    isStallCameraOn = true;
                    stallCamera.SetActive(true);
                    flashlight.SetActive(false);
                    mouseLook.mouseSensitivity = 0;

                    if (!trigger)
                    {
                        myBathroomDoor.SetBool("Open", true);
                        // ADD AUDIO
                    }
                }
            }

            else if (isStallCameraOn == true)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    isStallCameraOn = false;
                    stallCamera.SetActive(false);
                    flashlight.SetActive(true);
                    mouseLook.mouseSensitivity = 3;

                    if (trigger)
                    {
                        myBathroomDoor.SetBool("Open", false);
                    }
                }
            }

            // if (Input.GetKeyDown(KeyCode.R))
            // {
            //     if (!trigger)
            //     {
            //         myBathroomDoor.SetBool("Open", true);
            //         // ADD AUDIO
            //     }

            //     else
            //     {
            //     myBathroomDoor.SetBool("Open", false);
            //     // PLAY AUDIO
            //     }
            // }
        }

        if (hide.isHiding == false)
        {
            openBathroomDoorUI.SetActive(false);
        }
    }
}
