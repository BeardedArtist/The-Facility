using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantGoHereTeleport : MonoBehaviour
{
    public GameObject player;
    public GameObject warpTarget;

    private CharacterController characterController;
    [SerializeField] private bool trig;


    // Start is called before the first frame update
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
    }

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
        if (trig)
        {
            characterController.enabled = false;
            player.transform.position = warpTarget.transform.position;
            player.transform.rotation = warpTarget.transform.rotation;
            characterController.enabled = true;
        }
    }
}
