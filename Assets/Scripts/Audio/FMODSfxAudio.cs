using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODSfxAudio : MonoBehaviour
{
    // FMOD Parameters
    [SerializeField] EventReference eventName;
    private static FMOD.Studio.EventInstance SFX;


    // private void Start() 
    // {
    //     SFX = FMODUnity.RuntimeManager.CreateInstance(eventName);    
    // }


    // For Note_2 in the bathroom ------------------------
    public void BathroomNotePickUp_Audio()
    {
        StartCoroutine(startMonsterDoorAudio());
    }

    IEnumerator startMonsterDoorAudio()
    {
        yield return new WaitForSeconds(3.0f);
        PlayAudioThroughIEnumerator();
    }
    // For Note_2 in the bathroom ------------------------




    // For AI banging on bathroom doors --------------------------
    public void AiHitBathroomDoor_Audio()
    {
        StartCoroutine(AiHittingBathroomDoor());
    }

    public void AiHitBathroomDoor_Audio_Immediate()
    {
        PlayAudioImmediately();
    }

    IEnumerator AiHittingBathroomDoor()
    {
        yield return new WaitForSeconds(1.0f);

        if (!FMODExtension.IsPlaying(SFX))
        {
            PlayAudioThroughIEnumerator();
        }
    }


    // For AI banging on bathroom doors --------------------------




    // Stoppping SFX
    public void StopAudio()
    {
        if (FMODExtension.IsPlaying(SFX))
        {
            Debug.Log("Stopping Music");
            SFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            SFX.release();
        }
    }

    // Playing SFX
    public void PlayAudioThroughIEnumerator()
    {
        if (!FMODExtension.IsPlaying(SFX))
        {
            SFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
            SFX = FMODUnity.RuntimeManager.CreateInstance(eventName);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(SFX, GetComponent<Transform>());
            SFX.start();
            SFX.release();
        }
    }

    public void PlayAudioImmediately()
    {
            SFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
            SFX = FMODUnity.RuntimeManager.CreateInstance(eventName);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(SFX, GetComponent<Transform>());
            SFX.start();
            SFX.release();
    }
}

