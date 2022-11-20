using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2_Scare : MonoBehaviour
{
    [SerializeField] private GameObject behindTrigger;
    public FlickerControl flickerControl;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    private bool hasAudioPlayed = false;

    
    public void Trigger2()
    {
        behindTrigger.SetActive(true);
        flickerControl.isFlickering = true;
        
        if (!audioSource.isPlaying && hasAudioPlayed == false)
        {
            hasAudioPlayed = true;
            audioSource.PlayOneShot(audioClip);
        }
    }
}
