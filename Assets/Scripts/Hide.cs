using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject player;
    public GameObject warpTarget;
    public GameObject warpTarget_2;
    private CharacterController characterController;
    public GameObject aiController;
    [SerializeField] public bool isHiding = false;


    private bool trig;


    private void Start() 
    {
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        trig = true;    
    }
    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
    }

    private void Update() 
    {
        if (trig)
        {
            Debug.Log("Player can hide");

            if (isHiding == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Player is hiding!");

                    characterController.enabled = false;
                    player.transform.position = warpTarget.transform.position;
                    player.transform.rotation = warpTarget.transform.rotation;
                    characterController.enabled = true;

                    isHiding = true;
                    AIController script = aiController.GetComponent<AIController>();
                    script.playerisHidingBadly = true;

                }
            }

            else if (isHiding == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Player is not hiding anymore");

                    characterController.enabled = false;
                    player.transform.position = warpTarget_2.transform.position;
                    player.transform.rotation = warpTarget_2.transform.rotation;
                    characterController.enabled = true;

                    isHiding = false;
                }
            }
        }
    }

    // private void OnTriggerStay(Collider other) 
    //     {
    //         if (other.tag == "Player")
    //         {
    //             Debug.Log("Player is ready to hide");

    //             if (isHiding == false)
    //             {
    //                 if (Input.GetKeyDown(KeyCode.E))
    //                 {
    //                     Debug.Log("Player is hiding!");

    //                     characterController.enabled = false;
    //                     player.transform.position = warpTarget.transform.position;
    //                     player.transform.rotation = warpTarget.transform.rotation;
    //                     characterController.enabled = true;

    //                     isHiding = true;
    //                     aIController.playerisHidingBadly = true;
    //                 }
    //             }

    //             if (isHiding == true)
    //             {
    //                 if (Input.GetKeyDown(KeyCode.Q))
    //                 {
    //                     Debug.Log("Player is not hiding anymore");

    //                     characterController.enabled = false;
    //                     player.transform.position = warpTarget_2.transform.position;
    //                     player.transform.rotation = warpTarget.transform.rotation;
    //                     characterController.enabled = true;
    //                     //player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));

    //                     isHiding = false;
                        
    //                 }                  
    //             }
    //         }
    //     }


}
