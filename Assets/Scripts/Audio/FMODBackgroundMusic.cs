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
}
