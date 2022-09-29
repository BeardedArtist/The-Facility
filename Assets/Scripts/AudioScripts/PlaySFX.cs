using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private bool hasAudioPlayed = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            if (!audioSource.isPlaying && hasAudioPlayed == false)
            {
                audioSource.Play();
                hasAudioPlayed = true;
            }
        }
    }
}
