using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
   
    [SerializeField] private Animator myDoor = null;
    private bool trigger;
    private bool trig;
    [SerializeField] private bool isLocked;


    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    [SerializeField] private GameObject openDoorUI;


    // Start is called before the first frame update
    void Start()
    {
        myDoor = GetComponent<Animator>();

        myDoor.SetBool("Open", false);
        trigger = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
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

    void Update() 
    {
        if (trig && isLocked == false)
        {
            trigger = myDoor.GetBool("Open");

            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!trigger)
                {
                    myDoor.SetBool("Open", true);
                }
                else
                {
                    myDoor.SetBool("Open", false);
                }
            }
        }

        else if (trig && isLocked == true)
        {
            openDoorUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(audioClip);
                }
            }
        }
    }

    // private void OnTriggerStay(Collider other) 
    // {
    //     if (other.tag == "Player")
    //     {
    //         Debug.Log("Player is in range");
    //         trigger = myDoor.GetBool("Open");

    //         if(Input.GetKeyDown(KeyCode.E))
    //         {
    //             if (!trigger)
    //             {
    //                 myDoor.SetBool("Open", true);
    //             }
    //             else
    //             {
    //             myDoor.SetBool("Open", false);
    //             }
    //         }
    //     }
    // }
}
