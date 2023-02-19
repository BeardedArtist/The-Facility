using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeRedUSB : MonoBehaviour
{
    private bool Trig;
    public GameObject warpPlayerToAnomaly;
    private CharacterController characterController;
    public GameObject player;
    public GameObject completelyBlackOut_Anim;

    private void Start() 
    {
        characterController = player.GetComponent<CharacterController>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        Trig = true;    
    }

    private void OnTriggerExit(Collider other) 
    {
        Trig = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Trig == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                completelyBlackOut_Anim.SetActive(true);
                StartCoroutine(DelayBlackOut());
                
            }
        }
    }

    private IEnumerator DelayBlackOut()
    {
        yield return new WaitForSeconds (0.5f);
        characterController.enabled = false;
        player.transform.position = warpPlayerToAnomaly.transform.position;
        player.transform.rotation = warpPlayerToAnomaly.transform.rotation;
        characterController.enabled = true;
    }
}
