using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BathroomLightReveal : MonoBehaviour
{
    // TESTING
    [SerializeField] private GameObject[] objectsToDisappear;
    private bool hasAudioPlayed = false;
    // TESTING

    public void MakeCoroutineStart()
    {
        StartCoroutine(MakeObjectsAppear());
    }

    IEnumerator MakeObjectsAppear()
    {
        yield return new WaitForSeconds(3f);

        if (hasAudioPlayed == false)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Flood Light Turn On", GetComponent<Transform>().position);
            hasAudioPlayed = true;
        }

        for (int i = 0; i < objectsToDisappear.Length; i++)
        {
            objectsToDisappear[i].SetActive(false);
        }
    }
}
