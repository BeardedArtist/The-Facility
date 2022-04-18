using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Make sure to always have this for AI

public class AIController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform eyes; // creating a transform for the 'eyes' cone in the AI
    NavMeshAgent agent;
     
    private string state = "idle";
    private bool alive = true;
    private float wait = 0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    //check if we can see player
    public void CheckSight()
    {
        if (alive)
        {
            RaycastHit rayHit;
            if (Physics.Linecast(eyes.position, playerTransform.position, out rayHit)) // checks to see if the raycast intersects with anything
            {
                
                if (rayHit.collider.gameObject.name == "FirstPersonPlayer")
                {
                    print("hit " + rayHit.collider.gameObject.name);
                    //chase
                    if (state != "kill")
                    {
                        state = "chase";
                        //agent.speed = 5f;
                    }
                }
            } 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawLine(eyes.position, playerTransform.position, Color.green);
        if (alive)
        {
            // idle
            if (state == "idle")
            {
                // pick random location to walk to
                Vector3 randomPosition = Random.insideUnitSphere * 50f;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPosition, out navHit, 50f, NavMesh.AllAreas); // finding a random spot from where the AI is standing on the NavMesh
                agent.SetDestination(navHit.position); // setting the random position to the agent so it knows where to go. 
                state = "walk";
            }

            // walk
            if (state == "walk")
            {
                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending) // If AIs remaining distance is less than stopping distance AND AI is not calculating where to walk...
                {
                    state = "search"; // reset to "idle" which allows AI to find new position to walk
                    wait = 5f;
                } 
            }

            //search
            if (state == "search")
            {
                if (wait > 0f)
                {
                    wait -= Time.deltaTime;
                    transform.Rotate(0f, 120f * Time.deltaTime, 0f);
                }
                else 
                {
                    state = "idle";
                }
            }

            // chase
            if (state == "chase")
            {
                agent.destination = playerTransform.position;    
            }

            // agent.destination = playerTransform.position; // this gives the AI the players position and tells it to walk to the player
        }

        
    }
}
