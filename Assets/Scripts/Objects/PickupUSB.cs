using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupUSB : MonoBehaviour
{
    public GameObject player;
    public GameObject USB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player can pick up USB");
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(USB);
            }
        }
    }
}
