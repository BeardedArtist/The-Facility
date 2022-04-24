using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AU_Occlusion_Manager : MonoBehaviour
{

    private EventInstance Audio;
    private EventDescription AudioDes;
    private StudioListener Listener;
    private PLAYBACK_STATE pb;


    private AU_Occlusion_Details occlusionDetails;


    private bool AudioIsVirtual;
    private float MaxDistance;
    private float ListenerDistance;
    private float lineCastHitCount = 0f;
    private Color colour;


    //i am a random variable to recieve the min max out of the event, need to learn the syntax to make this unecessary
    private float test;


    //Called in cases where i forget to add occlusion details
    public void ManageOcclusion(EventInstance instance, EventReference reference)
    {
        Debug.LogError($"Audio Error: No Occlusion Details included on this {gameObject.name}");
    }

    //Sets all relevant variables, and gets the event description
    public void ManageOcclusion(EventInstance instance, EventReference reference, AU_Occlusion_Details details)
    {
        occlusionDetails = details;
        Audio = instance;
        AudioDes = RuntimeManager.GetEventDescription(reference);
        AudioDes.getMinMaxDistance(out test, out MaxDistance);

        Listener = FindObjectOfType<StudioListener>();

        //Debug.Log("OclusionManager Added");

    }



    //Checks if the player can hear the sound, and occludes it if that's the case
    private void FixedUpdate()
    {
        Audio.isVirtual(out AudioIsVirtual);
        Audio.getPlaybackState(out pb);
        ListenerDistance = Vector3.Distance(transform.position, Listener.transform.position);
        Debug.Log(pb);
        //Debug.Log($"!AudioIsVirtual = {!AudioIsVirtual} \n pb = {pb}");

        if (!AudioIsVirtual && pb == PLAYBACK_STATE.PLAYING || pb == PLAYBACK_STATE.SUSTAINING && ListenerDistance <= MaxDistance)
        {
            OccludeBetween(transform.position, Listener.transform.position);
            Debug.Log("Occluding");
        }
        lineCastHitCount = 0f;
    }


    //Occlusion function, draws multiple raycasts to get an idea of how occluded the object is
    private void OccludeBetween(Vector3 sound, Vector3 listener)
    {
        Debug.Log("Occluding Between");
        Vector3 SoundLeft = CalculatePoint(sound, listener, occlusionDetails.SoundOcclusionWidening, true);
        Vector3 SoundRight = CalculatePoint(sound, listener, occlusionDetails.SoundOcclusionWidening, false);

        Vector3 SoundAbove = new Vector3(sound.x, sound.y + occlusionDetails.SoundOcclusionWidening, sound.z);
        Vector3 SoundBelow = new Vector3(sound.x, sound.y - occlusionDetails.SoundOcclusionWidening, sound.z);

        Vector3 ListenerLeft = CalculatePoint(listener, sound, occlusionDetails.PlayerOcclusionWidening, true);
        Vector3 ListenerRight = CalculatePoint(listener, sound, occlusionDetails.PlayerOcclusionWidening, false);

        Vector3 ListenerAbove = new Vector3(listener.x, listener.y + occlusionDetails.PlayerOcclusionWidening * 0.5f, listener.z);
        Vector3 ListenerBelow = new Vector3(listener.x, listener.y - occlusionDetails.PlayerOcclusionWidening * 0.5f, listener.z);

        CastLine(SoundLeft, ListenerLeft);
        CastLine(SoundLeft, listener);
        CastLine(SoundLeft, ListenerRight);

        CastLine(sound, ListenerLeft);
        CastLine(sound, listener);
        CastLine(sound, ListenerRight);

        CastLine(SoundRight, ListenerLeft);
        CastLine(SoundRight, listener);
        CastLine(SoundRight, ListenerRight);

        CastLine(SoundAbove, ListenerAbove);
        CastLine(SoundBelow, ListenerBelow);

        if (occlusionDetails.PlayerOcclusionWidening == 0f || occlusionDetails.SoundOcclusionWidening == 0f)
        {
            colour = Color.blue;
        }
        else
        {
            colour = Color.green;
        }

        SetParameter();
    }

    //Calculates the points points of the raycasts
    private Vector3 CalculatePoint(Vector3 a, Vector3 b, float m, bool posOrneg)
    {
        float x;
        float z;
        float n = Vector3.Distance(new Vector3(a.x, 0f, a.z), new Vector3(b.x, 0f, b.z));
        float mn = (m / n);
        if (posOrneg)
        {
            x = a.x + (mn * (a.z - b.z));
            z = a.z - (mn * (a.x - b.x));
        }
        else
        {
            x = a.x - (mn * (a.z - b.z));
            z = a.z + (mn * (a.x - b.x));
        }
        return new Vector3(x, a.y, z);
    }

    //Raycasts
    private void CastLine(Vector3 Start, Vector3 End)
    {
        RaycastHit hit;
        Physics.Linecast(Start, End, out hit, occlusionDetails.OcclusionLayer);

        if (hit.collider)
        {
            lineCastHitCount++;
            Debug.DrawLine(Start, End, Color.red);
        }
        else
            Debug.DrawLine(Start, End, colour);
    }

    //Adjusts the occlusion level based on how many lines returned a hit
    private void SetParameter()
    {
        Audio.setParameterByName("Occlusion", lineCastHitCount / 11);
    }





}
