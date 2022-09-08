using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Occlusion Data")]
public class AU_Occlusion_Details : ScriptableObject
{
    //Width of the sound source (for occlusion purposes)
    [Header("Occlusion Options")]
    [Range(0f, 10f)]
    public float SoundOcclusionWidening = 1f;
    //Occlusion width for the player
    [Range(0f, 10f)]
    public float PlayerOcclusionWidening = 1f;

    //What layer the occlusion script will look for occlusions 
    public LayerMask OcclusionLayer;


}
