using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUZZLETEST : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        door.GetComponent<OpenCloseDoor>().enabled = false;
    }

    
    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player can reach USB");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(gameObject);
                door.GetComponent<OpenCloseDoor>().enabled = true;
            }
        }    
    }


}
