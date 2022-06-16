using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressCHECK : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log(Input.anyKeyDown + " was pressed");
        }
    }
}
