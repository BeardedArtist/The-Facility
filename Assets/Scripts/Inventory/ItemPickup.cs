using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        Destroy(gameObject);
        InventoryManager.Instance.Add(Item);
    }

    private void OnTriggerStay(Collider other) 
    {
        Debug.Log("Player in Area");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(Input.inputString);
            Pickup();
        }
    }
}
