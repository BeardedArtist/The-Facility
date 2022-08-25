using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeRecorderPickup : MonoBehaviour
{
    [SerializeField] private bool Trig;
    [SerializeField] private GameObject goBackMessage;

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            Trig = true;
        }    
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
                audioSource.Stop();
                goBackMessage.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
