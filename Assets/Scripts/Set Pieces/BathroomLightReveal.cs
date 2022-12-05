using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomLightReveal : MonoBehaviour
{
    // TESTING
    [SerializeField] private GameObject[] objectsToAppear;
    // TESTING

    public void MakeCoroutineStart()
    {
        StartCoroutine(MakeObjectsAppear());
    }

    IEnumerator MakeObjectsAppear()
    {
        yield return new WaitForSeconds(15f);

        for (int i = 0; i < objectsToAppear.Length; i++)
        {
            objectsToAppear[i].SetActive(true);
        }
    }
}
