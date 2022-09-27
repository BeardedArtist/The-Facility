using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare_2 : MonoBehaviour
{

    public GameObject AItoDisappear;
    public GameObject AItoAppear;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool hasAudioPlayed = false;

    private void Start() 
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            AItoDisappear.SetActive(false);
            AItoAppear.SetActive(true);

            if (hasAudioPlayed == false)
            {
                audioSource.PlayOneShot(audioClip);
                hasAudioPlayed = true;
            }
        }    
    }
}
