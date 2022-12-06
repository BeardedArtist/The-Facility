using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BathroomLightReveal : MonoBehaviour
{
    // TESTING
    [SerializeField] private GameObject[] objectsToAppear;
    private bool hasAudioPlayed = false;
    // TESTING

    public void MakeCoroutineStart()
    {
        StartCoroutine(MakeObjectsAppear());
    }

    IEnumerator MakeObjectsAppear()
    {
        yield return new WaitForSeconds(5f);

        if (hasAudioPlayed == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Flood Light Turn On", GetComponent<Transform>().position);
            hasAudioPlayed = true;
        }

        for (int i = 0; i < objectsToAppear.Length; i++)
        {
            objectsToAppear[i].SetActive(true);
        }
    }
}
