using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject player;
    public GameObject warpTarget;
    public GameObject warpTarget_2;
    private CharacterController characterController;
    [SerializeField] private bool isHiding = false;


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
                Debug.Log("Player is ready to hide");

                if (isHiding == false)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Player is hiding!");

                        // PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
                        // PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
                        // PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);

                        characterController.enabled = false;
                        player.transform.position = warpTarget.transform.position;
                        player.transform.rotation = warpTarget.transform.rotation;
                        characterController.enabled = true;

                        isHiding = true;
                    }
                }

                if (isHiding == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Player is not hiding anymore");

                        characterController.enabled = false;
                        player.transform.position = warpTarget_2.transform.position;
                        player.transform.rotation = warpTarget.transform.rotation;
                        characterController.enabled = true;
                        //player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));

                        isHiding = false;
                    }                  
                }
            }
        }


}
