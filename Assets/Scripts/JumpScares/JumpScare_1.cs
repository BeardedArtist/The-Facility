using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare_1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject AItoDisappear;

    public bool hasAudioPlayed = false;

    private void Start() 
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            AItoDisappear.SetActive(false);

            if (hasAudioPlayed == false)
            {
                audioSource.PlayOneShot(audioClip);
                hasAudioPlayed = true;
            }
            
        }    
    }
}
