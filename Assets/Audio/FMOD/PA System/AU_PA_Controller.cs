using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using static FMODUnity.RuntimeManager;
using FMOD.Studio;


public class AU_PA_Controller : MonoBehaviour
{

    private void Start()
    {
        AU_PA_Event_Manager.Instance.onPaStart += PaStart;
        AU_PA_Event_Manager.Instance.onPaStop += PaStop;
    }






    [SerializeField]
    private EventReference PaListener;
    private EventInstance paAnnouncement;
    private AU_Occlusion_Manager occlusionManager;

    [SerializeField]
    private AU_Occlusion_Details occlusionDetails;



    private void PaStart()
    {
        paAnnouncement = CreateInstance(PaListener);

        paAnnouncement.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        occlusionManager = gameObject.AddComponent<AU_Occlusion_Manager>();
        occlusionManager.ManageOcclusion(paAnnouncement, PaListener, occlusionDetails);

        SetUpOcclusion(PaListener);

        paAnnouncement.start();
    }



    private void PaStop(FMOD.Studio.STOP_MODE stopMode)
    {
        paAnnouncement.stop(stopMode);
        paAnnouncement.release();
        Destroy(occlusionManager);
    }







    private void SetUpOcclusion(EventReference eventReference)
    {
        /*  paAnnouncement.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
         occlusionManager = gameObject.AddComponent<AU_Occlusion_Manager>();
         occlusionManager.ManageOcclusion(paAnnouncement, eventReference, occlusionDetails); */
    }


}
