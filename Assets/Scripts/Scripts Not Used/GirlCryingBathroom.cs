using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCryingBathroom : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource_2;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip audioClip_2;
    [SerializeField] private GameObject Press_E;
    [SerializeField] private GameObject JumpScare;

    private bool Trig;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Trig = true;
            Press_E.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other) 
    {
        Trig = false;
        Press_E.SetActive(false);
    }

    private void Update() 
    {
        if (Trig == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                audioSource_2.PlayOneShot(audioClip_2);
                audioSource.Stop();
                Press_E.SetActive(false);
                JumpScare.SetActive(true);
                Destroy(gameObject.GetComponent<BoxCollider>());
                Trig = false;
            }
        }
    }
}
