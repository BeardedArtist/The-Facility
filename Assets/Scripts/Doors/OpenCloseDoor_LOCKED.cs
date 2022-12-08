using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor_LOCKED : MonoBehaviour
{
    private bool trig;
    [SerializeField] private GameObject openDoorUI;

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
            openDoorUI.SetActive(true);    
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        openDoorUI.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (trig)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Doors/Door LOCKED/LOCKEDDOORUPGRADEDRY", GetComponent<Transform>().position);
            }
        }
    }
}
