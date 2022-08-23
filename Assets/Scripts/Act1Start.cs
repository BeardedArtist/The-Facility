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
    //[SerializeField] private GameObject wakeUp_Anim;
    [SerializeField] private Animator wakeUp_Anim;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private MouseLook mouseLook;

    private bool canGetup = false;

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
        StartCoroutine(GetUpMessage());

        if (canGetup == true)
        {
            if (Input.anyKey)
            {
                Destroy(getUpMessage);
                characterController.enabled = true;
                mouseLook.enabled = true;
            }
        }
    }

    void StartActOne()
    {
        characterController.enabled = false;
        mouseLook.enabled = false;
        wakeUp_Anim.Play("CompleteBlackOut", 0, 0.0f);
    }

    private IEnumerator GetUpMessage()
    {
        yield return new WaitForSeconds(5.0f);
        getUpMessage.SetActive(true);
        canGetup = true;
    }
}
