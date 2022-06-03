using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public bool lightIsOn;

    void Start()
    {
        lightIsOn = false;
    }

    void Update()
    {
        if (lightIsOn == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.SetActive(true);
                lightIsOn = true;
                Debug.Log("flashlight is on");
            }
        }

        else if (lightIsOn == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.SetActive(false);
                lightIsOn = false;
                Debug.Log("Flashlight is off");
            }
        }
    }
}
