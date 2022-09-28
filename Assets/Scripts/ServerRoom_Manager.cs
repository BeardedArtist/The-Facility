using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerRoom_Manager : MonoBehaviour
{
    private bool trig;
    [SerializeField] private GameObject interactUI;

    public CircuitBreakerManager circuitBreakerManager;

    // For Hallway lights
    [SerializeField] private GameObject lightsToBeTurnedOff;
    // -------------------------

    // For PA System
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    // -------------------------

    // Activate AI
    [SerializeField] private GameObject ServerScene_AI;
    // -------------------------

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        interactUI.SetActive(false);
    }

    private void Update() 
    {
        if (trig)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (circuitBreakerManager.circuitBreakerOn >= 3)
                {
                    lightsToBeTurnedOff.SetActive(false);

                    if (audioSource != null && !audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(audioClip);
                        ServerScene_AI.SetActive(true);
                    }
                }

                else
                {
                    Debug.Log("There are some fuses still off");
                }
            }
        }    
    }
}
