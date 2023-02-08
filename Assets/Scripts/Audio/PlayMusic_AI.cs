using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic_AI : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] bool hasPlayed = false;

    private void Awake() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Books/PAGESRIPPING", GetComponent<Transform>().position);
        hasPlayed = true;   
    }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (other.tag == "Enemy" && !audioSource.isPlaying && hasPlayed == false)
    //     {
    //         //audioSource.Play();
    //         FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Books/PAGESRIPPING", GetComponent<Transform>().position);
    //         hasPlayed = true;
    //     }    
    // }
}
