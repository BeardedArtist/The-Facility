using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
   
    [SerializeField] private Animator myDoor = null;
    private bool trigger;


    // Start is called before the first frame update
    void Start()
    {
        myDoor = GetComponent<Animator>();

        myDoor.SetBool("Open", false);
        trigger = false;
    }

    // private void Update()
    // {
    //     trigger = myDoor.GetBool("Open");

    //     if(Input.GetKeyDown(KeyCode.E))
    //     {
    //         if (!trigger)
    //         {
    //             myDoor.SetBool("Open", true);
    //         }
    //         else
    //         {
    //             myDoor.SetBool("Open", false);
    //         }
    //     }
    // }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player is in range");
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
    }


    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (other.tag == "Player")
    //     {
    //         Debug.Log("Player in area");
    //         myDoor.Play("OpenDoor", 0, 0.0f);
    //         Debug.Log("Opening Door");

    //         // else if (isOpen == true)
    //         // {
    //         //     if (Input.GetKeyDown(KeyCode.E))
    //         //     {
    //         //         myDoor.Play("CloseDoor", 0, 0.0f);
    //         //         Debug.Log("Opening Door");
    //         //         isOpen = true;
    //         //     }
    //         // }      
    //     }
    // }
}
