using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
   
    [SerializeField] private Animator myDoor = null;
    private bool trigger;
    private bool trig;


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
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = false;
        }
    }

    void Update() 
    {
        if (trig)
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
