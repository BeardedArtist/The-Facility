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
    private bool isMethodFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = player.GetComponent<CharacterController>();
        mouseLook = playerCamera.GetComponent<MouseLook>();
        wakeUp_Anim = wakeUpAnimObject.GetComponent<Animator>();

        StartActOne();
        Invoke("GetUpMessage", 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("GetUpMessage", 5.0f);

        if (canGetup == true)
        {
            if (Input.anyKey)
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
        canGetup = true;
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
