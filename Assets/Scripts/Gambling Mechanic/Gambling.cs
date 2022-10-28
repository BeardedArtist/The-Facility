using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambling : MonoBehaviour
{
    [SerializeField] private GameObject question;
    [SerializeField] private GameObject hasMessage_UI;
    [SerializeField] public bool hasMessage = false;

    private bool trig;

    public MouseLook mouseLook;
    


    void Update()
    {
        if (hasMessage == true)
        {
            hasMessage_UI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.T))
            {
                //hasMessage_UI.SetActive(false);
                mouseLook.mouseSensitivity = 0;

                question.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void ButtonTest()
    {
        Debug.Log("Interesting");
        question.SetActive(false);
        hasMessage = false;
        hasMessage_UI.SetActive(false);

        mouseLook.mouseSensitivity = 3;
    }

    public void ButtonTest_No()
    {
        Debug.Log("I wonder...");
        question.SetActive(false);
        hasMessage = false;
        hasMessage_UI.SetActive(false);

        mouseLook.mouseSensitivity = 3;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
