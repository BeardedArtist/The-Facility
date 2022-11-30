using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeRecorderPickup : MonoBehaviour
{
    // Objects & Bools that won't be touched
    [SerializeField] private bool Trig;
    [SerializeField] private GameObject goBackMessage;
    [SerializeField] private GameObject InteractUI;
    [SerializeField] private MeshRenderer objectRender;
    public bool pickedUpTapeRecorder = false;
    public AudioSource audioSource;
    // Objects & Bools that won't be touched

    // Adding objects that will be effected
    // -------------------------------------------------------------------

    [SerializeField] private GameObject Part2Trigger;
    [SerializeField] private BoxCollider audioTrigger_Start;
    [SerializeField] private BoxCollider audioTrigger_Stop;
    

    // Adding objects that will be effected
    // -------------------------------------------------------------------

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            Trig = true;
            InteractUI.SetActive(true);
        }    
    }
    private void OnTriggerExit(Collider other) 
    {
        Trig = false;    
        InteractUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Trig == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                audioSource.Stop();
                goBackMessage.SetActive(true);
                StartCoroutine(closeMessage());
                objectRender.enabled = false;
                Part2Trigger.SetActive(true);
                pickedUpTapeRecorder = true;

                audioTrigger_Start.enabled = false;
                audioTrigger_Stop.enabled = true;
            }
        }
    }

    private IEnumerator closeMessage()
    {
        yield return new WaitForSeconds (5.0f);
        goBackMessage.SetActive(false);
        Destroy(gameObject);
    }
}
