using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambling : MonoBehaviour
{
    [SerializeField] private GameObject question;
    private bool trig;

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (other.tag == "Player")
    //     {
    //         trig = true;    
    //     }
    // }

    // private void OnTriggerExit(Collider other) 
    // {
    //     trig = false;    
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            question.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // if (trig == true)
        // {
        //     question.SetActive(true);
        //     Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
        // }

        // else
        // {
        //     question.SetActive(false);
        //     Cursor.lockState = CursorLockMode.Locked;
        //     {
                
        //     };
        // }
    }
}
