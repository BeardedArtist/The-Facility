using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare_DoorKnock : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    private bool hasAudioPlayed = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            if (hasAudioPlayed == false)
            {
                audioSource.PlayOneShot(audioClip);
                hasAudioPlayed = true;
            }
        }    
    }
}
