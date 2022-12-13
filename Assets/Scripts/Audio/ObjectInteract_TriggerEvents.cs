using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class ObjectInteract_TriggerEvents : MonoBehaviour
{
    public UnityEvent OnInteract;

    private bool trig;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
    }

    private void Update() 
    {
        ObjectInteraction();    
    }

    private void ObjectInteraction()
    {
        if (trig == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteract.Invoke();
            }
        }
    }
}
