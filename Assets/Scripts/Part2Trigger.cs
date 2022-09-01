using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2Trigger : MonoBehaviour
{
    [SerializeField] private GameObject warpPlayerToAnomaly;
    [SerializeField] private GameObject player;
    private CharacterController characterController;

    [SerializeField] private Animator BlackoutAnimation;

    // Start is called before the first frame update
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {          
            BlackoutAnimation.SetBool("PlayBlackOut", true);
            StartCoroutine(DelayTransition());

            if (this.BlackoutAnimation.GetCurrentAnimatorStateInfo(0).IsName("PlayBlackOut"))
            {
                BlackoutAnimation.SetBool("PlayBlackOut", false);
            }
        }
    }

    private IEnumerator DelayTransition()
    {
        yield return new WaitForSeconds(0.5f);
        characterController.enabled = false;
        player.transform.position = warpPlayerToAnomaly.transform.position;
        player.transform.rotation = warpPlayerToAnomaly.transform.rotation;
        characterController.enabled = true;
    }
}
