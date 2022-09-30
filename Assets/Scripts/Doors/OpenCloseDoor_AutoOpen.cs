using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor_AutoOpen : MonoBehaviour
{
   
    [SerializeField] private Animator myDoor = null;
    private bool trigger;
    private bool trig;


    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    //[SerializeField] private GameObject openDoorUI;
    [SerializeField] private bool hasDoorOpened = false;
    //public DoorTrigger doorTrigger;


    // Start is called before the first frame update
    void Start()
    {
        myDoor = GetComponent<Animator>();
        //doorTrigger = GetComponent<DoorTrigger>();

        myDoor.SetBool("Open", false);
        trigger = false;
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = true;
            //openDoorUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        //openDoorUI.SetActive(false);
    }

    void Update() 
    {
        if (trig && hasDoorOpened == false)
        {
            trigger = myDoor.GetBool("Open");
            if (!trigger)
            {
                myDoor.SetBool("Open", true);

                if (!audioSource.isPlaying && audioSource != null)
                {
                    audioSource.PlayOneShot(audioClip);
                }
            }
                // else
                // {
                //     myDoor.SetBool("Open", false);

                //     if (!audioSource.isPlaying && audioSource != null)
                //     {
                //         audioSource.PlayOneShot(audioClip);
                //     }
                // }
        }
    }
}
