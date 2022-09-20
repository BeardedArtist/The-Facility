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

    [SerializeField] private Light pLight_1;
    [SerializeField] private Light pLight_2;
    [SerializeField] private Light pLight_3;
    private Color colorGreen = Color.green;

    [SerializeField] private Material greenMat;
    // -------------------------


    // For Hallway lights
    [SerializeField] private GameObject lightsToBeTurnedOn;
    // -------------------------


    // For Scary Moment with AI
    [SerializeField] private GameObject creepyAI;
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
            pLight_1.color = colorGreen;
        }

        if (circuitBreakerOn == 2)
        {
            mainCircuit_2.GetComponent<MeshRenderer>().material = greenMat;
            pLight_2.color = colorGreen;
        }

        if (circuitBreakerOn == 3)
        {
            mainCircuit_3.GetComponent<MeshRenderer>().material = greenMat;
            pLight_3.color = colorGreen;

            lightsToBeTurnedOn.SetActive(true);

            if (creepyAI != null)
            {
                creepyAI.SetActive(true);
            }
        }
    }
}
