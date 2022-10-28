using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambling_ActivateBool : MonoBehaviour
{
    public Gambling gambling;
    private bool trig;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            //trig = true;
            gambling.hasMessage = true;
            Destroy(this);
        }    
    }
}
