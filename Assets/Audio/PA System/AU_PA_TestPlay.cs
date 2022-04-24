using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using static FMODUnity.RuntimeManager;


public class AU_PA_TestPlay : MonoBehaviour
{


    [SerializeField]
    private EventReference testTransmitterEvent;
    private EventInstance transmitterInstance;


    void Start()
    {

        AU_PA_Event_Manager.Instance.PaStart();
        transmitterInstance = CreateInstance(testTransmitterEvent);
        transmitterInstance.start();
    }

    private void Update()
    {
        if (!CheckPlaybackState())
        {
            AU_PA_Event_Manager.Instance.PaStop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }


    private bool CheckPlaybackState()
    {
        PLAYBACK_STATE playbackState;
        transmitterInstance.getPlaybackState(out playbackState);
        if (playbackState == PLAYBACK_STATE.STOPPED)
        {
            return false;
        }
        return true;
    }

}
