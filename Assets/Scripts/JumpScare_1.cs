using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare_1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject AItoDisappear;

    private void Start() 
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            AItoDisappear.SetActive(false);
            audioSource.PlayOneShot(audioClip);
            //Destroy(gameObject);
        }    
    }
}
