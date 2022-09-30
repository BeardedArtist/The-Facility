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

    // UI
    [SerializeField] private GameObject powerNotOn_Message;
    [SerializeField] private float Timer = 5;
    // -------------------------

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
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
                    PowerNotOnMessage();
                }
            }
        }    
    }

    void PowerNotOnMessage()
    {
        powerNotOn_Message.SetActive(true);
        StartCoroutine(turnOfMessage());
    }

    private IEnumerator turnOfMessage()
    {
        yield return new WaitForSeconds(3.0f);
        powerNotOn_Message.SetActive(false);
    }
}
