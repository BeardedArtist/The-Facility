using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindTrigger : MonoBehaviour
{
    public FlickerControl flickerControl;
    public Flashlight flashlight;
    [SerializeField] private GameObject lightToBeTurnedOff;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    
    private bool hasAudioPlayed = false;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            if (!audioSource.isPlaying && hasAudioPlayed == false)
            {
                hasAudioPlayed = true;
                audioSource.PlayOneShot(audioClip);

                flickerControl.enabled = false;
                lightToBeTurnedOff.SetActive(false);

                flashlight.lightIsOn = false;
            }
        }    
    }
}
