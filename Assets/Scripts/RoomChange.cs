using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public GameObject hallwayOne;
    public GameObject hallwayTwo;

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
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Room will appear");

                hallwayOne.SetActive(false);
                hallwayTwo.SetActive(true);
            }
        }    
    }
}
