using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambling_ActivateBool : MonoBehaviour
{
    public Gambling gambling;
    private bool trig;

    [SerializeField] private Collider thisCollider;


    public int TriggerID;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("The Current Trigger ID is " + TriggerID);
            gambling.hasMessage = true;
            thisCollider.enabled = false;
        }    
    }
}
