using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Pickup : MonoBehaviour
{
    private bool Trig;
    public GameObject playersFlashlight;

    private void OnTriggerEnter(Collider other) 
    {
        Trig = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        Trig = false;
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
            }
        }
    }
}
