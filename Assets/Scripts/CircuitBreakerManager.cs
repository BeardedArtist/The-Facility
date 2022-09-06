using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreakerManager : MonoBehaviour
{
    [SerializeField] private Material greenMat;
    [SerializeField] private GameObject lightObject;

    [SerializeField] private Light pLight;
    private Color colorGreen = Color.green;

    [SerializeField] private int circuitBreakerOn;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;


    [SerializeField] private bool hasTurnedOn = false;
    private bool Trig;

    

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Trig = true;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        Trig = false;    
    }

    private void Update() 
    {
        if (Trig == true)
        {
            if (Input.GetKey(KeyCode.E) && hasTurnedOn == false)
            {
                circuitBreakerOn += 1;
                audioSource.PlayOneShot(audioClip);
                lightObject.GetComponent<MeshRenderer>().material = greenMat;
                pLight.color = colorGreen;
                hasTurnedOn = true;
            }
        }
    }
}
