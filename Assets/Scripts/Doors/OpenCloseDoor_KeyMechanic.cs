using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor_KeyMechanic : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    private bool trigger;
    private bool trig;
    private bool hasKey = false;

    // [SerializeField] private AudioSource audioSource;
    // [SerializeField] private AudioClip audioClip_1;
    // [SerializeField] private AudioClip audioClip_2;

    [SerializeField] private GameObject doorUI;

    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private Item itemScript;
    [SerializeField] private GameObject RedKey;


    // Start is called before the first frame update
    void Start()
    {
        myDoor = GetComponent<Animator>();
        //inventoryManager = GetComponent<InventoryManager>();

        myDoor.SetBool("Open", false);
        trigger = false;    
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Flashlight Eyes 2")
        {
            trig = true;
            doorUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;
        doorUI.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (trig)
        {
            if (inventoryManager.hasRedKey == true)
            {
                Debug.Log("You Got the Key!");
            }
            // trigger = myDoor.GetBool("Open");

            // if (Input.GetKeyDown(KeyCode.E))
            // {

            // }
        }
    }
}
