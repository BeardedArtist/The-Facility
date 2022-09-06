using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreakerManager : MonoBehaviour
{
    [SerializeField] private int circuitBreakerOn;

    public void IncrementNumber()
    {
        circuitBreakerOn++;
    }
}
