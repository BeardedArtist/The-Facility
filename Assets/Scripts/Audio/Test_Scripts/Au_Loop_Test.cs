using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;



public class Au_Loop_Test : MonoBehaviour
{
    [SerializeField]
    private EventReference loop;
    private EventInstance instance;

    private void Start()
    {
        PlayLoop();

    }


    private void PlayLoop()
    {
        instance = RuntimeManager.CreateInstance(loop);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>());
        instance.start();
        
    }



}
