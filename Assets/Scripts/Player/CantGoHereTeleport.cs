using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantGoHereTeleport : MonoBehaviour
{
    public GameObject player;
    public Transform warpTarget;

    [SerializeField] private GameObject topLid;
    [SerializeField] private GameObject bottomLid;
    [SerializeField] private Animator blink_Anim;
    [SerializeField] private Animator blink_Anim_2;
    [SerializeField] bool isBlinking;
    [SerializeField] private float timer; // DONT NEED

    private CharacterController characterController;
    [SerializeField] private bool trig;


    // Start is called before the first frame update
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            // blink_Anim.Play("TopLidBlink", 0, 0.0f);
            // blink_Anim_2.Play("BottomLidBlink", 0, 0.0f);
            //characterController.enabled = false;
            Debug.Log("Player Entered");
            Vector3 offset = other.transform.position - transform.position;
            other.transform.position = warpTarget.position + offset;


        }
    }


    // // Update is called once per frame
    // void Update()
    // {
    //     if (trig)
    //     {
    //         //StartCoroutine(blinkTransition());
    //     }
    // }

    // IEnumerator blinkTransition()
    // {
    //     yield return new WaitForSeconds(0.8f);
    //     characterController.enabled = false;
    //     player.transform.position = warpTarget.transform.position;
    //     player.transform.rotation = warpTarget.transform.rotation;

    //     characterController.enabled = true;
    // }
}
