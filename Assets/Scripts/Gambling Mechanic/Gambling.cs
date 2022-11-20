using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gambling : MonoBehaviour
{
    [SerializeField] private GameObject question;
    [SerializeField] private GameObject hasMessage_UI;
    [SerializeField] private GameObject phone_UI;
    [SerializeField] int ScareMeterDecider;
    [SerializeField] int ScareMeter = 0;
    [SerializeField] public bool hasMessage = false;
    private bool trig;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] bool audioPlayed = false;

    // TESTING Scare function ---------------------
    [SerializeField] private GameObject GamblingScare_Test;
    public PushObject_Scare pushObject_Scare;
    public Trigger2_Scare trigger2_Scare;

    // Change sound
    // Add player speed up

    // TESTING Scare function ---------------------

    public MouseLook mouseLook;
    public PlayerMovement playerMovement;
    public Gambling_ActivateBool gambling_ActivateBool;

    [SerializeField] public float timer;
    [SerializeField] private bool timerIsOn = false;
    [SerializeField] private TextMeshProUGUI timerText;


    // Timer Slider Test
    [SerializeField] private Slider timerSlider;
    private bool stopTimer;

    private void Start() 
    {
        ScareMeterDecider = Random.Range(1,10);   
        timer = 10f;

        stopTimer = false;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;
    }
    


    void Update()
    {
        if (hasMessage == true)
        {
            if (!audioSource.isPlaying && audioPlayed == false)
            {
                audioSource.PlayOneShot(audioClip);
                audioPlayed = true;
            }

            question.SetActive(true);
            phone_UI.SetActive(true);
            mouseLook.mouseSensitivity = 0;
            playerMovement.walkSpeed = 0;
            

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            timerText.text = timer.ToString();
            Timer();
            //StartCoroutine(showMessage());
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
            phone_UI.SetActive(false);
            hasMessage = false;
            hasMessage_UI.SetActive(false);

            mouseLook.mouseSensitivity = 3;
            playerMovement.walkSpeed = 3;

            CheckTriggerID();
        }

        else
        {
            ScareMeter--;
            Debug.Log("Interesting");
            question.SetActive(false);
            phone_UI.SetActive(false);
            hasMessage = false;
            hasMessage_UI.SetActive(false);

            mouseLook.mouseSensitivity = 3;
            playerMovement.walkSpeed = 3;
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
            phone_UI.SetActive(false);
            hasMessage = false;
            hasMessage_UI.SetActive(false);

            mouseLook.mouseSensitivity = 3;
            playerMovement.walkSpeed = 3;

            CheckTriggerID();
        }

        else
        {
            ScareMeter--;
            Debug.Log("Interesting");
            question.SetActive(false);
            phone_UI.SetActive(false);
            hasMessage = false;
            hasMessage_UI.SetActive(false);

            mouseLook.mouseSensitivity = 3;
            playerMovement.walkSpeed = 3;
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
                pushObject_Scare.TriggerOneScare();
            }
        }

        if (gambling_ActivateBool.TriggerID == 2)
        {
            if (ScareMeter >= 1)
            {
                trigger2_Scare.Trigger2();
            }
        }
        
    }

    // IEnumerator showMessage()
    // {
    //     yield return new WaitForSeconds(1f);
    //     mouseLook.mouseSensitivity = 0;
    //     playerMovement.walkSpeed = 0;

    //     question.SetActive(true);
    //     Cursor.lockState = CursorLockMode.None;
    //     Cursor.visible = true;
        
    // }

    void Timer()
    {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timerText.text = timer.ToString();
            }

            if (timer <= 0)
            {
                stopTimer = true;
                Debug.Log("Time is up!");
                question.SetActive(false);
                phone_UI.SetActive(false);
                ScareMeter++;
            }


            if (stopTimer == false)
            {
                timerSlider.value = timer;
            }
    }
}
