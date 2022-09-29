using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Act1Start : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject wakeUpAnimObject;
    [SerializeField] private GameObject PCMessage;
    [SerializeField] private GameObject getUpMessage;
    [SerializeField] private Animator wakeUp_Anim;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private MouseLook mouseLook;

    private bool canGetup = false;
    private bool canGetUpMessageIsFinished = false;
    private bool isMethodFinished = false;


    // TESTING STARTING CONVERSATION
    [SerializeField] private GameObject text_1;
    [SerializeField] private bool text_1IsFinished = false;
    // TESTING STARTING CONVERSATION

    // Start is called before the first frame update
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        mouseLook = playerCamera.GetComponent<MouseLook>();
        wakeUp_Anim = wakeUpAnimObject.GetComponent<Animator>();

        StartActOne();

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("StartUpConversation", 2.0f);

        if (canGetup == true)
        {
            if (Input.anyKeyDown)
            {
                getUpMessage.SetActive(false);
                characterController.enabled = true;
                mouseLook.enabled = true;

                isMethodFinished = true;
            }
        }


        if (isMethodFinished == true)
        {
            Invoke("TurnOffMethod", 5.0f);
        }
    }

    void StartActOne()
    {
        characterController.enabled = false;
        mouseLook.enabled = false;
        wakeUp_Anim.Play("CompleteBlackOut", 0, 0.0f);
    }

    void GetUpMessage()
    {
        getUpMessage.SetActive(true);
        canGetUpMessageIsFinished = true;
        canGetup = true;
    }


    void StartUpConversation()
    {
        if (text_1IsFinished == false)
        {
            text_1.SetActive(true);

            if (Input.anyKeyDown)
            {
                text_1IsFinished = true;
                text_1.SetActive(false);
            }
        }

        if (text_1IsFinished == true && canGetUpMessageIsFinished == false)
        {
            Invoke("GetUpMessage", 2.0f);
        }
    }

    // private IEnumerator GetUpMessage()
    // {
    //     yield return new WaitForSeconds(5.0f);
    //     getUpMessage.SetActive(true);
    //     canGetup = true;
    // }

    void TurnOffMethod()
    {
        enabled = false;
    }
}
