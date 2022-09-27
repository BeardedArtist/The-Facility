using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpenCloseDoor_JumpScare : MonoBehaviour
{
    private bool trig;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject openDoorUI;

    [SerializeField] private GameObject jumpScare_Running;

    public AIController_RunningJumpScare jumpScare_Trigger;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = true;
            openDoorUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        openDoorUI.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (trig)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(audioClip);
                    jumpScare_Trigger.Invoke("JumpScare_Running", 1f);
                }
            }
        }
    }
}
