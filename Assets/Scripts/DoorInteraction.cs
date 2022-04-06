using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    [SerializeField] private bool isDoorOpen = false;
    [SerializeField] private int doorSpeed = 10;


    Vector3 startPosition;
    Vector3 endPosition;
    Vector3 difference;

    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            Debug.Log("Player is in reach");
        }    
    }

    public void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActive && isDoorOpen == false && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
            isDoorOpen = true;
        }
        
        else if (triggerActive && isDoorOpen == true && Input.GetKeyDown(KeyCode.E))
        {
            CloseDoor();
            isDoorOpen = false;
        }
    }

    public void OpenDoor()
    {
        transform.Translate(-2,0,0);
    }

    public void CloseDoor()
    {
        transform.Translate(2,0,0);
    }
}
