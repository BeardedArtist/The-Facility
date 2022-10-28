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

    // Things to Appear
    [SerializeField] private GameObject thingsToAppear;
    [SerializeField] private GameObject extraLightToTurnOff;
    // --------------------------

    private void OnTriggerStay(Collider other) 
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
                    extraLightToTurnOff.SetActive(false);
                    thingsToAppear.SetActive(true);
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Music/WESTMINSTER_BELLS_2", GetComponent<Transform>().position);
                    ServerScene_AI.SetActive(true);

                    // if (audioSource != null && !audioSource.isPlaying)
                    // {
                    //     audioSource.PlayOneShot(audioClip);
                    //     ServerScene_AI.SetActive(true);
                    // }
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
