using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AU_TestOcclusion_Player : MonoBehaviour
{
    [SerializeField]
    private EventReference testAudio;

    [SerializeField]
    private AU_Occlusion_Details occlusion_Details;

    private EventInstance currentAudio;

    private AU_Occlusion_Manager occManager;



    //
    void Start()
    {
        // Loads the test bank
        AU_Event_Manager.Instance.LoadBank("Tests");
        //Instantiates the audio event
        currentAudio = RuntimeManager.CreateInstance(testAudio);
        //sets its location to the gameobject
        currentAudio.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        //Instantiates an occlusion manager
        occManager = gameObject.AddComponent<AU_Occlusion_Manager>();
        //Sends the audio to have it's occlusion managed
        occManager.ManageOcclusion(currentAudio, testAudio, occlusion_Details);
        //Starts the event
        currentAudio.start();
    }

}
