using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject player;
    public GameObject warpTarget;
    private CharacterController characterController;
    private void Start() 
    {
        characterController = player.GetComponent<CharacterController>();
    }

    private void Update() 
    {
        
    }

    private void OnTriggerStay(Collider other) 
        {
            if (other.tag == "Player")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Player is read to hide");
                    characterController.enabled = false;
                    player.transform.position = warpTarget.transform.position;
                    characterController.enabled = true;
                }
                
            }
        }


}
