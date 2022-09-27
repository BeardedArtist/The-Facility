using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare_RunnningFootsteps : MonoBehaviour
{
    private bool trig;

    private void OnTriggerEnter(Collider other) 
    {
        trig = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
