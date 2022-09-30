using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController_WalkCreepy : MonoBehaviour
{
    public Transform pointToWalkTo;
    public NavMeshAgent agent;
    public GameObject eventTrigger;
    private bool isWalking = false;

    [SerializeField] private MeshRenderer meshRenderer;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    private void Update() 
    {
        if (isWalking == true)
        {
            CreepyWalk();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            meshRenderer.enabled = false;
            agent.destination = pointToWalkTo.position;
            isWalking = true;
            Destroy(eventTrigger);
        }
    }

    private void CreepyWalk() 
    {
        if (agent.remainingDistance < 0.1)
        {
            Destroy(gameObject);
            isWalking = false;
        }

        // if (!agent.pathPending)
        //     {
        //         if (agent.remainingDistance <= agent.stoppingDistance)
        //         {
        //             if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
        //             {
        //                 Destroy(eventTrigger);
        //             }
        //         }
        //     }
    }
}
