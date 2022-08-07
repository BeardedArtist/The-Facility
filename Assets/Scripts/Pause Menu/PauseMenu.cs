using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject optionsMenuUI;
    [SerializeField] private bool isPaused;
    [SerializeField] private bool isOptionsOpen;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivateMenu();
        }

        else
        {
            DeactivateMenu();
        }    
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void ActivateOptionsMenu()
    {
        isOptionsOpen = true;
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void DeactivateOptionsMenu()
    {
        isOptionsOpen = false;
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
