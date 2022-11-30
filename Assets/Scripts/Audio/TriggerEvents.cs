using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            OnEnter.Invoke();
        }
    }
}
