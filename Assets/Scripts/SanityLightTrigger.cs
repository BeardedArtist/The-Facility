using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityLightTrigger : MonoBehaviour
{
    public Sanity sanity;

    public GameObject lightsToTurnOn;
    public GameObject lightsToTurnOff;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && sanity.sanityPercentage >= 30f)
        {
            lightsToTurnOn.SetActive(true);
            lightsToTurnOff.SetActive(false);
            Destroy(gameObject);
        }    
    }
}
