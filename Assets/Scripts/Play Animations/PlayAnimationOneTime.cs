using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOneTime : MonoBehaviour
{
    // Animator References
    [SerializeField] private Animator animator_OneShot;
    [SerializeField] private GameObject interactUI;

    // Bool Reference
    private bool trig;
    private bool hasAnimationPlayed = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true; 
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;   
        interactUI.SetActive(false); 
    }

    private void Update() 
    {
        if (trig == true && hasAnimationPlayed == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayAnimation();
                hasAnimationPlayed = true;
            }
        }    
    }

    private void PlayAnimation()
    {
        Debug.Log("Animation should play");
        animator_OneShot.Play("MoveCounter_Anim", 0, 0);
    }
}
