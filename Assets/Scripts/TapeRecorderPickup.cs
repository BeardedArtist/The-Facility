using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeRecorderPickup : MonoBehaviour
{
    [SerializeField] private bool Trig;
    [SerializeField] private GameObject goBackMessage;
    [SerializeField] private GameObject Part2Trigger;

    [SerializeField] private GameObject InteractUI;
    [SerializeField] private MeshRenderer objectRender;

    public bool pickedUpTapeRecorder = false;

    public AudioSource audioSource;

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
