using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrototypeYellowUSB : MonoBehaviour
{
    private bool Trig;
    public GameObject AIComingToGetYou;
    public GameObject bathroomUSB;
    public GameObject RunAwayMessage;

    // public AudioSource audioSource;
    // public AudioClip audioClip;


    private void OnTriggerEnter(Collider other) 
    {
        Trig = true;    
    }
    private void OnTriggerExit(Collider other) 
    {
        Trig = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Trig == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                AIComingToGetYou.SetActive(true);
                bathroomUSB.SetActive(true);
                RunAwayMessage.SetActive(true);
                Destroy(gameObject);
                //audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
