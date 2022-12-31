using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoorWithTrigger : MonoBehaviour
{
    // Simple Script to Unlock door upon entering trigger

    // Script References
    [SerializeField] private OpenCloseDoor openCloseDoor_Script;
    [SerializeField] private OpenCloseDoor_LOCKED openCloseDoor_LOCKED_Script;

    // Bool Reference
    private bool trig;
    

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
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
        if (trig == true)
        {
            openCloseDoor_LOCKED_Script.enabled = false;
            openCloseDoor_Script.enabled = true;
        }    
    }
}
