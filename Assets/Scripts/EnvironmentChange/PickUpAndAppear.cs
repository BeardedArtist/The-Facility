using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndAppear : MonoBehaviour
{
    // This simple script is to handle when a player picks up an item 
    // and we want something to appear. 

    [SerializeField] private GameObject objectToAppear;
    [SerializeField] private Item pickedUpObject;
    [SerializeField] private InventoryManager inventoryManager;
    private bool trig = false;

    private void OnTriggerStay(Collider other) 
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

    private void Update() 
    {
        if (trig)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectToAppear.SetActive(true);
            }
        }    
    }

    private void CheckPickedUpObject()
    {
        for (int i = 0; i < inventoryManager.Items.Count; i++)
        {
            if (inventoryManager.Items[i] == pickedUpObject)
            {
                Debug.Log("Player Picked up object");
            }
        }
    }
}
