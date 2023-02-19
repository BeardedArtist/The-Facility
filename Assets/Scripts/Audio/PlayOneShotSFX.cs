using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayOneShotSFX : MonoBehaviour
{
    // This script should play Audio only once! 

    private bool hasAudioPlayed = false;
    [SerializeField] private string eventName;


    public void PlaySfxOnce()
    {
        if (hasAudioPlayed == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot(eventName);
            hasAudioPlayed = true;
        }
    }
}
