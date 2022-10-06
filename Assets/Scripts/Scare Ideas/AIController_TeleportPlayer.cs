using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_TeleportPlayer : MonoBehaviour
{
    [SerializeField] private GameObject warpPlayerToLocation;
    [SerializeField] private GameObject player;

    private bool trig;
    private CharacterController characterController;
    [SerializeField] private Animator BlackoutAnimation;

    // Start is called before the first frame update
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
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
        if (trig == true)
        {
            BlackoutAnimation.SetBool("PlayBlackOut", true);
            StartCoroutine(TeleportPlayer());

            if (this.BlackoutAnimation.GetCurrentAnimatorStateInfo(0).IsName("PlayBlackOut"))
            {
                BlackoutAnimation.SetBool("PlayBlackOut", false);
            }
        }
    }

    private IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        characterController.enabled = false;
        player.transform.position = warpPlayerToLocation.transform.position;
        player.transform.rotation = warpPlayerToLocation.transform.rotation;
        characterController.enabled = true;
    }
}
