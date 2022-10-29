using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambling : MonoBehaviour
{
    [SerializeField] private GameObject question;
    [SerializeField] private GameObject hasMessage_UI;
    [SerializeField] int ScareMeterDecider;
    [SerializeField] int ScareMeter;
    [SerializeField] public bool hasMessage = false;
    private bool trig;

    public MouseLook mouseLook;

    private void Start() 
    {
        ScareMeterDecider = Random.Range(1,10);    
    }
    


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
        if (ScareMeterDecider >= 1 && ScareMeterDecider <= 5)
        {
            ScareMeter++;
            ScareMeterDecider = Random.Range(1,10);    
            Debug.Log("Wrong Answer");
            question.SetActive(false);
            hasMessage = false;
            hasMessage_UI.SetActive(false);

            mouseLook.mouseSensitivity = 3;
        }

        else
        {
            ScareMeter--;
            Debug.Log("Interesting");
            question.SetActive(false);
            hasMessage = false;
            hasMessage_UI.SetActive(false);

            mouseLook.mouseSensitivity = 3;
        }
    }

    public void ButtonTest_No()
    {
        if (ScareMeterDecider >= 6 && ScareMeterDecider <= 11)
        {
            ScareMeter++;
            ScareMeterDecider = Random.Range(1,10);    
            Debug.Log("Wrong Answer");
            question.SetActive(false);
            hasMessage = false;
            hasMessage_UI.SetActive(false);

            mouseLook.mouseSensitivity = 3;
        }

        else
        {
            ScareMeter--;
            Debug.Log("Interesting");
            question.SetActive(false);
            hasMessage = false;
            hasMessage_UI.SetActive(false);

            mouseLook.mouseSensitivity = 3;
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
