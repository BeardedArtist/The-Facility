using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool BoxColliderTriggered;
    [SerializeField] private GameObject openDoorUI;

    public void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            BoxColliderTriggered = true;
            openDoorUI.SetActive(true);

        }    
    }

    public void OnTriggerExit(Collider other) 
    {
        BoxColliderTriggered = false;    
        openDoorUI.SetActive(false);
    }
}
