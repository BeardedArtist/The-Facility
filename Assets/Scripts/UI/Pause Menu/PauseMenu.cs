using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject optionsMenuUI;
    [SerializeField] private bool isPaused;
    [SerializeField] private bool isOptionsOpen;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private MouseLook mouseLook;

    [SerializeField] EventReference mainThemeMusic;
    private static FMOD.Studio.EventInstance Music;

    private void Start() 
    {
        mouseLook = mainCamera.GetComponent<MouseLook>();    
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            if (!FMODExtension.IsPlaying(Music))
            {
                Music = FMODUnity.RuntimeManager.CreateInstance(mainThemeMusic);
                Music.start();
            }

            Time.timeScale = 0;
            AudioListener.pause = true;
            Cursor.lockState = CursorLockMode.Confined;
            mouseLook.enabled = false;
            pauseMenuUI.SetActive(true);

            if (isOptionsOpen)
            {
                pauseMenuUI.SetActive(false);
                optionsMenuUI.SetActive(true);
            }
        }

        else
        {
            //DeactivateMenu();
        }    
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);

        if (isOptionsOpen == true)
        {
            pauseMenuUI.SetActive(false);
        }
        else if (isOptionsOpen == false)
        {
            pauseMenuUI.SetActive(true);
            optionsMenuUI.SetActive(false);
        }
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        //Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        mouseLook.enabled = true;
        isPaused = false;
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI Sounds/Menu UI DETUNE");

        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Music.release();
    }

    public void ActivateOptionsMenu()
    {
        isOptionsOpen = true;
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI Sounds/Menu UI DETUNE");
    }

    public void DeactivateOptionsMenu()
    {
        isOptionsOpen = false;
        optionsMenuUI.SetActive(false);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI Sounds/Menu UI DETUNE");
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
