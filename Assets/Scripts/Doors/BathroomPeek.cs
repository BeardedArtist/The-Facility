using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomPeek : MonoBehaviour
{
    [SerializeField] private Animator myBathroomDoor = null;
    [SerializeField] private GameObject openBathroomDoorUI;
    private bool trigger;
    private bool trig;

    // Start is called before the first frame update
    void Start()
    {
        myBathroomDoor = GetComponent<Animator>();

        myBathroomDoor.SetBool("Open", false);
        trigger = false;
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
            openBathroomDoorUI.SetActive(true);
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        openBathroomDoorUI.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (trig)
        {
            trigger = myBathroomDoor.GetBool("Open");

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!trigger)
                {
                    myBathroomDoor.SetBool("Open", true);
                    // ADD AUDIO
                }

                else
                {
                myBathroomDoor.SetBool("Open", false);
                // PLAY AUDIO
                }
            }
        }
    }
}
