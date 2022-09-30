using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPop : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject lightToDestroy;

    private bool hasAudioPlayed = false;


    public Flashlight flashlightScript;

    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && hasAudioPlayed == false)
        {
            audioSource.PlayOneShot(audioClip);
            Destroy(lightToDestroy);
            hasAudioPlayed = true;

            flashlightScript.flashlight.SetActive(false);
            flashlightScript.lightIsOn = false;
        }    
    }
}
