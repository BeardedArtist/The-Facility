using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_ServerSearch_Eyes : MonoBehaviour
{
    public bool alive = true;
    public GameObject foundPlayer;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") // if the collided object (the cone) is "Eyes"  
        {
            GetComponentInParent<AIController_ServerSearch>().CheckSight();
            // references the CheckSight() method in the AIController
        }  
    }
}
