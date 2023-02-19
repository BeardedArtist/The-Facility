using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChangeUpdate : MonoBehaviour
{
    public GameObject objectToDisappear;
    public GameObject ObjectToAppear;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            objectToDisappear.SetActive(false);
            ObjectToAppear.SetActive(true);
        }    
    }
}
