using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{

    private void Update() 
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Application has Quit");
        Application.Quit();
    }
}
