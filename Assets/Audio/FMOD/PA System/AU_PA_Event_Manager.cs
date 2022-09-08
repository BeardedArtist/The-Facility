using System;
using UnityEngine;
using FMODUnity;


public class AU_PA_Event_Manager : MonoBehaviour
{
    private static AU_PA_Event_Manager _instance;
    public static AU_PA_Event_Manager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public event Action onPaStart;

    public void PaStart()
    {
        if (onPaStart != null)
        {
            onPaStart();
        }
    }


    public event Action<FMOD.Studio.STOP_MODE> onPaStop;

    public void PaStop(FMOD.Studio.STOP_MODE stopMode)
    {
        if (onPaStop != null)
        {
            onPaStop(stopMode);
        }
    }
}
