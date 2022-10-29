using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Pickup : MonoBehaviour
{
    private bool Trig;
    public GameObject playersFlashlight;
    public GameObject pickUpUI;
    public bool pickedUpFlashlight = false;

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            Trig = true;
            pickUpUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Trig = false;
        pickUpUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Trig == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(gameObject);
                playersFlashlight.SetActive(true);
                pickedUpFlashlight = true;
            }
        }
    }
}
