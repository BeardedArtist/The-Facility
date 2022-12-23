using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearDisappear : MonoBehaviour
{
    // Simple code designed to make objects appear/disappear

    // Array for objects that will appear
    [SerializeField] private GameObject[] objectsToAppear;
    [SerializeField] private GameObject[] objectsToDisappear;

    public void EnvironmentChange()
    {
        for (int i = 0; i < objectsToAppear.Length; i++)
        {
            objectsToAppear[i].SetActive(true);
        }

        for (int i = 0; i < objectsToDisappear.Length; i++)
        {
            objectsToDisappear[i].SetActive(false);
        }
    }
}
