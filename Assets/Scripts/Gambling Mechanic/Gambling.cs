using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambling : MonoBehaviour
{
    [SerializeField] private GameObject question;
    [SerializeField] private GameObject hasMessage_UI;
    [SerializeField] int ScareMeterDecider;
    [SerializeField] int ScareMeter = 0;
    [SerializeField] public bool hasMessage = false;
    private bool trig;

    // TESTING Scare function ---------------------
    [SerializeField] private GameObject GamblingScare_Test;
    // TESTING Scare function ---------------------

    public MouseLook mouseLook;
    public Gambling_ActivateBool gambling_ActivateBool;

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

            CheckTriggerID();
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

            CheckTriggerID();
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

    public void CheckTriggerID()
    {
        if (gambling_ActivateBool.TriggerID == 1)
        {
            if (ScareMeter >= 1)
            {
                GamblingScare_Test.SetActive(true);
            }
        }
        
    }
}
