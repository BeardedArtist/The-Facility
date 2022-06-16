using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    private bool trig;

    void Pickup()
    {
        Destroy(gameObject);
        InventoryManager.Instance.Add(Item);
    }

    private void OnTriggerEnter(Collider other) 
    {
        trig = true;
    }
    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
    }

    private void FixedUpdate() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }    
    }

    // private void OnTriggerStay(Collider other) 
    // {
    //     Debug.Log("Player in Area");

    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         Debug.Log(Input.inputString);
    //         Pickup();
    //     }
    // }
}
