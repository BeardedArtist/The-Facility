using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor_KeyMechanic : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    private bool trigger;
    private bool trig;
    private bool hasKey = false;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip_1;
    [SerializeField] private AudioClip audioClip_2;

    [SerializeField] private GameObject doorUI;

    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private Item itemScript;
    [SerializeField] private bool hasRedKey;


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

    private void checkForItem()
    {
        for (int I = 0; I < inventoryManager.Items.Count; I++)
        {
            if (inventoryManager.Items[I].name == "RedKey")
            {
                hasRedKey = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkForItem();
        
        if (trig)
        {
            trigger = myDoor.GetBool("Open");

            if (Input.GetKeyDown(KeyCode.E) && hasRedKey == false)
            {
                audioSource.PlayOneShot(audioClip_2);
            }


            else if (Input.GetKeyDown(KeyCode.E) && hasRedKey == true)
            {
                if (!trigger)
                {
                    myDoor.SetBool("Open", true);

                    if (!audioSource.isPlaying && audioSource != null)
                    {
                        audioSource.PlayOneShot(audioClip_1);
                    }
                }
                else
                {
                    myDoor.SetBool("Open", false);

                    if (!audioSource.isPlaying && audioSource != null)
                    {
                        audioSource.PlayOneShot(audioClip_1);
                    }
                }
            }
        }
    }


    
}
