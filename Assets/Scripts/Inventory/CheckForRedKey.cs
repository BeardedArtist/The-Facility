using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForRedKey : MonoBehaviour
{
    // Script to Check for Utility Room Key (Red Key)
    [SerializeField] private InventoryManager inventoryManager;
    //[SerializeField] private GameObject objectsToAppear;

    [SerializeField] private GameObject[] objectsToAppear;
    [SerializeField] private GameObject[] objectsToDisappear;

    private bool hasRedKey = false;
    private bool trig = false;

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
    }

    private void CheckingForRedKey()
    {
        for (int i = 0; i < inventoryManager.Items.Count; i++)
        {
            if (inventoryManager.Items[i].name == "RedKey")
            {
                hasRedKey = true;
            }
        }
    }


    private void Update() 
    {
        if (trig)
        {
            CheckingForRedKey();

            if (hasRedKey == true)
            {
                for (int i = 0; i < objectsToAppear.Length; i++)
                {
                    objectsToAppear[i].SetActive(true);
                }

                for (int i = 0; i < objectsToDisappear.Length; i++)
                {
                    objectsToDisappear[i].SetActive(false);
                }
            }
        }
    }
}
