using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic_AI : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] bool hasPlayed = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy" && !audioSource.isPlaying && hasPlayed == false)
        {
            audioSource.Play();
            hasPlayed = true;
        }    
    }
}
