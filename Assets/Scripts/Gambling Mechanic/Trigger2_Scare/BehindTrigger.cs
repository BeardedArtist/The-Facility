using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindTrigger : MonoBehaviour
{
    public FlickerControl flickerControl;
    [SerializeField] public Flashlight flashlightScript;
    [SerializeField] private GameObject lightToBeTurnedOff;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    
    private bool hasAudioPlayed = false;
    private bool hasColliderTriggered = false;

    [SerializeField] private Collider thisCollider;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2" && hasColliderTriggered == false)
        {
            if (!audioSource.isPlaying && hasAudioPlayed == false)
            {
                hasAudioPlayed = true;
                audioSource.PlayOneShot(audioClip);
            }

            flickerControl.enabled = false;
            lightToBeTurnedOff.SetActive(false);

            flashlightScript.flashlight.SetActive(false);
            flashlightScript.lightIsOn = false;

            hasColliderTriggered = true;
        }    
    }
}
