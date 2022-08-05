using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject warpTarget;
    private CharacterController characterController;

    private void Start() 
    {
        characterController = player.GetComponent<CharacterController>();    
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            characterController.enabled = false;
            player.transform.position = warpTarget.transform.position;
            player.transform.rotation = warpTarget.transform.rotation;
            characterController.enabled = true;
        } 
    }
}
