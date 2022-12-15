using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject player;
    public GameObject warpTarget;
    public GameObject warpTarget_2;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private MeshRenderer mainPlayerMesh;
    [SerializeField] private Footsteps footsteps;

    private PlayerMovement playerMovement;
    private CharacterController characterController;
    


    [SerializeField] private GameObject hideUI;


    [SerializeField] private bool trig;
    [SerializeField] public bool isHiding = false;


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
            if (isHiding == false)
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
                    isHiding = true;   


                    // ** Need to get rid of these? **
                    // AIController script = aiController.GetComponent<AIController>();
                    // script.playerisHidingBadly = true;

                }
            }

            else if (isHiding == true)
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
                    isHiding = false;

                    // ** Need to get rid of these? **
                    // AIController script = aiController.GetComponent<AIController>();
                    // script.playerisHidingBadly = false;
                }
            }
        }
    }


}
