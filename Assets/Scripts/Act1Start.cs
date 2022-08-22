using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Act1Start : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject PCMessage;
    //[SerializeField] private GameObject wakeUp_Anim;
    [SerializeField] private Animator wakeUp_Anim;
    [SerializeField] private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        wakeUp_Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartActOne()
    {
        characterController.enabled = false;
        wakeUp_Anim.Play("CompleteBlackOut", 0, 0.0f);
    }
}
