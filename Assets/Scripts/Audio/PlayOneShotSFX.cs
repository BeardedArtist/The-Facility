using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayOneShotSFX : MonoBehaviour
{
    [SerializeField] private string eventName;


    public void PlaySfxOnce()
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventName);
    }
}
