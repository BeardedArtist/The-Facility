using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    private bool trig;

    void Pickup()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Item Interaction/KEYSPICKUPECHO", GetComponent<Transform>().position);
        Destroy(gameObject);
        InventoryManager.Instance.Add(Item);
    }

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

    private void Update() 
    {
        if (trig)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
            }    
        }
    }
}
