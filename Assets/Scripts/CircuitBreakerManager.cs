using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreakerManager : MonoBehaviour
{
    [SerializeField] private int circuitBreakerOn;

    // For Main Circuit Breaker Lights
    [SerializeField] private GameObject mainCircuit_1;
    [SerializeField] private GameObject mainCircuit_2;
    [SerializeField] private GameObject mainCircuit_3;

    [SerializeField] private Light pLight;
    private Color colorGreen = Color.green;

    [SerializeField] private Material greenMat;
    // -------------------------

    private void Update() 
    {
        turnOnMainCircuitLights();    
    }

    public void IncrementNumber()
    {
        circuitBreakerOn++;
    }

    void turnOnMainCircuitLights()
    {
        if (circuitBreakerOn == 1)
        {
            mainCircuit_1.GetComponent<MeshRenderer>().material = greenMat;
            pLight.color = colorGreen;
        }

        if (circuitBreakerOn == 2)
        {
            mainCircuit_1.GetComponent<MeshRenderer>().material = greenMat;
            pLight.color = colorGreen;
        }

        if (circuitBreakerOn == 3)
        {
            mainCircuit_1.GetComponent<MeshRenderer>().material = greenMat;
            pLight.color = colorGreen;
        }
    }
}
