using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODBackgroundMusic : MonoBehaviour
{
    // FMOD Parameters -----------------------------
    [SerializeField] EventReference eventName;
    private static FMOD.Studio.EventInstance Music;
    // FMOD Parameters -----------------------------


    public void PlayAudio()
    {

        if (!FMODExtension.IsPlaying(Music))
        {
            Music = FMODUnity.RuntimeManager.CreateInstance(eventName);
            Music.start();
        }
    }

    public void StopAudio()
    {
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Music.release();
    }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (other.tag == "Player")
    //     {
    //         Music = FMODUnity.RuntimeManager.CreateInstance(eventName);
    //         Music.start();
    //     } 
    // }



    // private void Update() 
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Music = FMODUnity.RuntimeManager.CreateInstance(eventName);
    //         Music.start();
    //     }

    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    //         Music.release();
    //     }    
    // }

    // private void OnDestroy() // Music will fade out if scene changes
    // {
    //     Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);    
    // }



    // Add below method when we get a better grasp on FMOD
    // -------------------------------------------------------

    // public void Progress (float ProgressLevel)
    // {
    //     Music.setParameterByName("Progress", ProgressLevel);
    // }

    // Add above method when we get a better grasp on FMOD
    // -------------------------------------------------------
}
