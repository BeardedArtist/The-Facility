using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI Sounds/Menu UI DETUNE", GetComponent<Transform>().position);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI Sounds/Menu UI DETUNE", GetComponent<Transform>().position);
        Application.Quit();
    }

    IEnumerator loadGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
}
