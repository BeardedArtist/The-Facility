using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrap : MonoBehaviour
{
    // Script to shut the door behind the player

    // TODO:
    // --> Have door animate shut behind them.
    // --> Have shutting door audio (FMOD)
    [SerializeField] private Animator myDoor = null;
    private bool trigger;
    private bool trig;
    private bool hasDoorClosed = false;

    [SerializeField] private OpenCloseDoor openCloseDoor;
    [SerializeField] private OpenCloseDoor_LOCKED openCloseDoor_LOCKED;

    // ADD AUDIO HERE


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
            trigger = myDoor.GetBool("Open");

            if (trigger && hasDoorClosed == false)
            {
                myDoor.SetBool("Open", false); // close door via bool
                hasDoorClosed = true;

                openCloseDoor.enabled = false;
                openCloseDoor_LOCKED.enabled = true;

                // ADD AUDIO
            }

            if (!trigger)
            {
                openCloseDoor.enabled = false;
                openCloseDoor_LOCKED.enabled = true;
            }
        }
    }
}
