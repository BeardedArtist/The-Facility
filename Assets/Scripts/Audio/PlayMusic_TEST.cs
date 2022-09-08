using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic_TEST : MonoBehaviour
{
    [SerializeField] private bool hasPlayed;

    [SerializeField] private AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            audioSource.Play();
        }    
    }
}
