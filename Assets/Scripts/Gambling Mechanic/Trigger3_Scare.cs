using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3_Scare : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private bool hasAudioPlayed = false;


    public void TriggerThreeScare_Audio()
    {
        if (!audioSource.isPlaying && hasAudioPlayed == false)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
