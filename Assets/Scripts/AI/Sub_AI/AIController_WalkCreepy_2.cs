using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController_WalkCreepy_2 : MonoBehaviour
{
    public Transform pointToWalkTo;
    public NavMeshAgent agent;
    public GameObject eventTrigger;
    private bool isWalking = false;

    Animator anim;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();    

        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if (isWalking == true)
        {
            HandleAnimation();
            CreepyWalk();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
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
            anim.SetBool("isCrawling", false);
            isWalking = false;
        }
    }

    private void HandleAnimation()
    {
        anim.SetBool("isCrawling", true);
    }
}
