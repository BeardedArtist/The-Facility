using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_AIChaseKill : MonoBehaviour
{
    [SerializeField] private GameObject AI_Chase;
    private bool trig;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            trig = true;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (trig)
        {
            AI_Chase.SetActive(false);
        }
    }
}
