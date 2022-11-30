using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODBackgroundMusic : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;

    void Start()
    {
        // Music = FMODUnity.RuntimeManager.CreateInstance("event:/Level Music/LEVEL_MUSIC");
        // Music.start(); // Disable this later
        // Music.release();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Music = FMODUnity.RuntimeManager.CreateInstance("event:/Level Music/LEVEL_MUSIC");
            Music.start(); // Disable this later
            //Music.release();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Music.release();
        }    
    }

    public void Progress (float ProgressLevel)
    {
        Music.setParameterByName("Progress", ProgressLevel);
    }


    private void OnDestroy() // Music will fade out if scene changes
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);    
    }
}
