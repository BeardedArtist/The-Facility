using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomOpenDoorNonEuclidean : MonoBehaviour
{
    // Animator Reference
    [SerializeField] private Animator myBathroomDoor_NonEuclidean = null;

    // Bool References
    public bool canTransition = false;
    private bool trigger;


    // Start is called before the first frame update
    void Start()
    {
        myBathroomDoor_NonEuclidean = GetComponent<Animator>();
        myBathroomDoor_NonEuclidean.SetBool("Open", false);

        trigger = false;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (hideBathroomScene_Script.isHidingInBathroom == true && noteScript.isBathroomNotePickedUp == true && bathroomAI_Object is null)
    //     {

    //     }
    // }

    public void BathroomDoorSmoothOpen()
    {
        if (canTransition == true)
        {
            trigger = myBathroomDoor_NonEuclidean.GetBool("Open");

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!trigger)
                {
                    myBathroomDoor_NonEuclidean.SetBool("Open", true);
                    // ADD AUDIO
                }
            }
        }

        // else if (Input.GetKeyDown(KeyCode.E))
        // {
        //     if (trigger)
        //     {
        //         myBathroomDoor_NonEuclidean.SetBool("Open", false);
        //     }
        // }
    }
}
