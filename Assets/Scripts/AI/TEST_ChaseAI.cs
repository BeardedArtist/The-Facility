using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ChaseAI : MonoBehaviour
{
    [SerializeField] private GameObject AI_Chase;
    private bool trig;
    private bool hasAlreadyAppeared = false;

    private void OnTriggerEnter(Collider other) 
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

    // Update is called once per frame
    void Update()
    {
        if (trig && hasAlreadyAppeared == false)
        {
            AI_Chase.SetActive(true);
            hasAlreadyAppeared = true;
        }
    }
}
