using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODExtension : MonoBehaviour
{
    public static bool IsPlaying(FMOD.Studio.EventInstance instance)
    {
        FMOD.Studio.PLAYBACK_STATE state;
        instance.getPlaybackState(out state);
        return state != FMOD.Studio.PLAYBACK_STATE.STOPPED;
    }
}
