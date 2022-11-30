using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic_TEST : MonoBehaviour
{
    // [SerializeField] public AudioSource audioSource;
    // [SerializeField] bool hasPlayed = false;

    //private FMOD.Studio.EventInstance Music;

    public Flashlight_Pickup flashlight_PickupScript;
    public TapeRecorderPickup tapeRecorderPickupScript;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")  // !audioSource.isPlaying && hasPlayed == false
        {
            // TEST
            // Music = FMODUnity.RuntimeManager.CreateInstance("event:/Level Music/The Red Room");    
            // Music.start();
            // Music.release();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Level Music/The Red Room", GetComponent<Transform>().position);

            // audioSource.Play();
            // hasPlayed = true;
        }


        if (other.tag == "Player" && flashlight_PickupScript.pickedUpFlashlight == true && tapeRecorderPickupScript.pickedUpTapeRecorder == true)
        {
            //Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //Music.release();
            //OnDestroy();
        }   
    }


    // private void OnDestroy() 
    // {
    //     Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);    
    // }
}
