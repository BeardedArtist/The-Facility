using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomOpenDoorNonEuclidean : MonoBehaviour
{
    // Game Object Refereces
    [SerializeField] private GameObject OpenDoorUI;

    // Animator Reference
    [SerializeField] private Animator myBathroomDoor_NonEuclidean = null;

    // Bool References
    public bool trig;
    private bool trigger;


    // Start is called before the first frame update
    void Start()
    {
        myBathroomDoor_NonEuclidean = GetComponent<Animator>();
        myBathroomDoor_NonEuclidean.SetBool("Open", false);

        trigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
            OpenDoorUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        OpenDoorUI.SetActive(false);    
    }

    private void Update() 
    {
        if (trig)
        {
            trigger = myBathroomDoor_NonEuclidean.GetBool("Open");

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!trigger)
                {
                    myBathroomDoor_NonEuclidean.SetBool("Open", true); 
                    // ADD FMOD AUDIO
                }

                else
                {
                    myBathroomDoor_NonEuclidean.SetBool("Open", false);
                    // ADD FMOD AUDIO
                }
            }
        }    
    }
}
