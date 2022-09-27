using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController_RunningJumpScare : MonoBehaviour
{
    [SerializeField] private GameObject jumpScareToActivate;
    [SerializeField] private Transform playerTransform;
    public NavMeshAgent agent;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    public void JumpScare_Running()
    {
        jumpScareToActivate.SetActive(true);
        agent.destination = playerTransform.position;
    }
}
