using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare_2 : MonoBehaviour
{

    public GameObject AItoDisappear;
    public GameObject AItoAppear;

    private void Start() 
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            AItoDisappear.SetActive(false);
            AItoAppear.SetActive(true);
            Destroy(gameObject);
        }    
    }
}
