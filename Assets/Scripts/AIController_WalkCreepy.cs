using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController_WalkCreepy : MonoBehaviour
{
    public Transform pointToWalkTo;
    public NavMeshAgent agent;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            agent.destination = pointToWalkTo.position;

            float dist = agent.remainingDistance;

            if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
            {
                Destroy(gameObject);
            }

            // if (agent.remainingDistance <= agent.stoppingDistance + 1f && !agent.pathPending)
            // {
            //     Destroy(gameObject);
            // }
        }
    }

    private void Update() 
    {
        
    }
}
