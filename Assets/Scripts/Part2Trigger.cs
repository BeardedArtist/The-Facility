using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2Trigger : MonoBehaviour
{
    [SerializeField] private GameObject warpPlayerToAnomaly;
    [SerializeField] private GameObject player;
    private CharacterController characterController;

    [SerializeField] private Animator BlackoutAnimation;

    //TESTING BLINK ANIMATION
    [SerializeField] private Animator blink_Anim;
    [SerializeField] private Animator blink_Anim_2;
    // TESTING BLINK ANIMATION

    public Flashlight_Pickup flashlight_PickupScript;
    public TapeRecorderPickup tapeRecorderPickupScript;

    // Start is called before the first frame update
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && flashlight_PickupScript.pickedUpFlashlight == true && tapeRecorderPickupScript.pickedUpTapeRecorder == true)
        {          
            //BlackoutAnimation.SetBool("PlayBlackOut", true);

            if (this.blink_Anim.GetCurrentAnimatorStateInfo(0).IsName("TopLidBlink") && this.blink_Anim_2.GetCurrentAnimatorStateInfo(0).IsName("BottomLidBlink"))
            {
                blink_Anim.Play("TopLidBlink", 0, 0);
                blink_Anim_2.Play("BottomLidBlink", 0, 0);
            }

            StartCoroutine(DelayTransition());

            // if (this.BlackoutAnimation.GetCurrentAnimatorStateInfo(0).IsName("PlayBlackOut"))
            // {
            //     BlackoutAnimation.SetBool("PlayBlackOut", false);
            // }
        }
    }

    private IEnumerator DelayTransition()
    {
        yield return new WaitForSeconds(0.7f);
        characterController.enabled = false;
        player.transform.position = warpPlayerToAnomaly.transform.position;
        player.transform.rotation = warpPlayerToAnomaly.transform.rotation;
        characterController.enabled = true;
    }
}
