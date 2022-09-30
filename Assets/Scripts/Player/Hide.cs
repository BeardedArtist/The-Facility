using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject player;
    public GameObject warpTarget;
    public GameObject warpTarget_2;
    [SerializeField] private GameObject flashlight;
    private CharacterController characterController;
    public GameObject aiController;
    [SerializeField] public bool isHiding = false;
    [SerializeField] private MeshRenderer mainPlayerMesh;


    [SerializeField] private GameObject hideUI;


    [SerializeField] private bool trig;


    private void Start() 
    {
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = true;    
            hideUI.SetActive(true);
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
            Debug.Log("Player can hide");

            if (isHiding == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Player is hiding!");

                    characterController.enabled = false;
                    flashlight.SetActive(false);
                    mainPlayerMesh.enabled = false;
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
                    flashlight.SetActive(true);
                    player.transform.position = warpTarget_2.transform.position;
                    player.transform.rotation = warpTarget_2.transform.rotation;
                    characterController.enabled = true;
                    mainPlayerMesh.enabled = true;

                    isHiding = false;
                    AIController script = aiController.GetComponent<AIController>();
                    script.playerisHidingBadly = false;
                }
            }
        }
    }


}
