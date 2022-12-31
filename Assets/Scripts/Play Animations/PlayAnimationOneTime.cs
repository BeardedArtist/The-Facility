using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOneTime : MonoBehaviour
{
    // Animator References
    [SerializeField] private Animator animator_OneShot;

    // Bool Reference
    private bool trig;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true; 
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
    }

    private void PlayAnimation()
    {
        animator_OneShot.Play("");
    }
}
