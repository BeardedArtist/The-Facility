using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform slidingDoor;
    [SerializeField] private float doorSpeed = 1f;
    [SerializeField] private float sizeOfDoorInX = 1f;
    [SerializeField] private float amountOfDoorSlided = 0.9f;

    private Vector3 slidingDoorCloseTarget;
    private Vector3 slidingDoorOpenTarget;
    private float startTime;
    private float totalDistanceToCover;
    private bool isDoorCurrentlyOpen = false;
    private bool isDoorCurrentlyClosed = false;
    [SerializeField] private bool isDoorOpen = false;
    [SerializeField] private bool triggerActive = false;

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


    private void Start() 
    {
        SetInitialReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActive && isDoorOpen == false && Input.GetKeyDown(KeyCode.E))
        {
            
            OpenDoor();
        }
        
        else if (triggerActive && isDoorOpen == true && Input.GetKeyDown(KeyCode.E))
        {
            
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        //startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * doorSpeed;
        float fractionOfJourney = distanceCovered / totalDistanceToCover;
        slidingDoor.localPosition = Vector3.Lerp(slidingDoor.localPosition, slidingDoorOpenTarget, fractionOfJourney);

        if (Mathf.Approximately(slidingDoor.localPosition.x, slidingDoorOpenTarget.x))
        {
            Debug.Log("Doors Opened");
            isDoorOpen = true;
        }
    }

    public void CloseDoor()
    {
        //startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * doorSpeed;
        float fractionOfJourney = distanceCovered / totalDistanceToCover;
        slidingDoor.localPosition = Vector3.Lerp(slidingDoor.localPosition, slidingDoorCloseTarget, fractionOfJourney);

        if (Mathf.Approximately(slidingDoor.localPosition.x, slidingDoorCloseTarget.x))
        {
            Debug.Log("Doors Closed");
            isDoorOpen = false;
        }
    }

    void SetInitialReferences()
    {
        slidingDoorCloseTarget = slidingDoor.localPosition;

        slidingDoorOpenTarget = new Vector3(slidingDoor.localPosition.x - (sizeOfDoorInX * amountOfDoorSlided), slidingDoor.localPosition.y, slidingDoor.localPosition.z);

        totalDistanceToCover = Vector3.Distance(slidingDoorCloseTarget, slidingDoorOpenTarget);
    }
}
