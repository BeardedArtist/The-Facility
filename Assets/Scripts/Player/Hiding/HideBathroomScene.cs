using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBathroomScene : MonoBehaviour
{
    // Object References
    public GameObject player;
    public GameObject warpTarget;
    public GameObject warpTarget_2;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private MeshRenderer mainPlayerMesh;
    
    // Script References
    [SerializeField] private Footsteps footsteps;
    [SerializeField] private Notes noteScript;
    [SerializeField] private BathroomPeek bathroomPeekScript;
    private PlayerMovement playerMovement;
    private CharacterController characterController;

    // AI Script & Object Reference
    [SerializeField] private GameObject bathroomAI_Object;
    [SerializeField] private GameObject AI_WalkingPoints;
    private AIController_ServerSearch bathroomAI_Script;
    

    // Bool References
    [SerializeField] private GameObject hideUI;
    [SerializeField] private bool trig;
    [SerializeField] public bool isHidingInBathroom = false;
    [SerializeField] public bool AiIsActive = false;
    [SerializeField] public bool bathroomSceneIsActive;


    private void Start() 
    {
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;    
            // hideUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
        hideUI.SetActive(false);
    }

    private void Update() 
    {
        if (trig)
        {
            if (isHidingInBathroom == false)
            {
                hideUI.SetActive(true); 

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Player is hiding!");
                    hideUI.SetActive(false);

                    characterController.enabled = false;
                    //flashlight.SetActive(false);
                    mainPlayerMesh.enabled = false;
                    player.transform.position = warpTarget.transform.position;
                    player.transform.rotation = warpTarget.transform.rotation;
                    characterController.enabled = true;

                    // other scripts
                    player.GetComponent<PlayerMovement>().enabled = false;
                    footsteps.GetComponent<Footsteps>().enabled = false;

                    // Bools
                    isHidingInBathroom = true;

                    if (noteScript.isBathroomNotePickedUp == true)
                    {
                        bathroomAI_Object.SetActive(true);
                        AI_WalkingPoints.SetActive(true);
                        //enabled = false;

                        AiIsActive = true;
                        bathroomSceneIsActive = true;
                    }
                }
            }

            // else if (isHidingInBathroom == true && noteScript.isBathroomNotePickedUp == true && bathroomAI_Object is null)
            // {
            //     bathroomOpenDoorNonEuclidean_Script.canTransition = true;
            //     bathroomOpenDoorNonEuclidean_Script.BathroomDoorSmoothOpen();
            // }


            else if (isHidingInBathroom == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Player is not hiding anymore");

                    characterController.enabled = false;
                    //flashlight.SetActive(true);
                    player.transform.position = warpTarget_2.transform.position;
                    player.transform.rotation = warpTarget_2.transform.rotation;
                    characterController.enabled = true;
                    mainPlayerMesh.enabled = true;

                    // Other Scripts
                    player.GetComponent<PlayerMovement>().enabled = true;
                    footsteps.GetComponent<Footsteps>().enabled = true;
                    
                    // Bools
                    isHidingInBathroom = false;
                }
            }




            if (noteScript.isBathroomNotePickedUp == true)
            {
                if (AiIsActive == false && bathroomSceneIsActive == false)
                {
                    AI_WalkingPoints.SetActive(false);
                    // enabled = true;
                }
            }
        }
    }

    public void EnableHide()
    {
        enabled = true;
    }

    public void DisableHide()
    {
        enabled = false;
    }
}
