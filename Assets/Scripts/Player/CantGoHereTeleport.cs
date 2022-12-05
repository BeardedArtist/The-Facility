using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantGoHereTeleport : MonoBehaviour
{
    public Transform warpTarget;
    private bool trig = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Entered");
            Vector3 offset = other.transform.position - transform.position;
            other.transform.position = warpTarget.position + offset;
        }
    }
}
