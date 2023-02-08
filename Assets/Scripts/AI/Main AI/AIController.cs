using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using UnityEngine.SceneManagement;


public class AIController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform eyes; // creating a transform for the 'eyes' cone in the AI
    NavMeshAgent agent;
     
    [SerializeField] private string state = "idle";
    private bool alive = true;
    [SerializeField] private float wait = 0f;
    private bool highAlert = false;
    [SerializeField] private float alertTime = 50f;
    public bool playerisHidingBadly = false;

    public GameObject deathCam;
    public Transform deathCamPosition;
    public GameObject mainPlayer;
    public MeshRenderer mainPlayerMesh;
    player Player;
    PlayerMovement playerMovement;


    // TEST FOR ANIMATIONS
    Animator animator;
    // ADD FOOTSTEPS

    // TEST FOR ANIMATIONS


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GetComponent<player>();
        playerMovement = GetComponent<PlayerMovement>();

        // TEST
        animator = GetComponent<Animator>();
        // TEST
    }

    //check if we can see player
    public void CheckSight()
    {
        if (alive)
        {
            RaycastHit rayHit;
            if (Physics.Linecast(eyes.position, playerTransform.position, out rayHit)) // checks to see if the raycast intersects with anything
            {
                print("hit " + rayHit.collider.gameObject.name);
                if (rayHit.collider.gameObject.name == "FirstPersonPlayer")
                {
                    print("hit " + rayHit.collider.gameObject.name);
                    //chase
                    if (state != "kill")
                    {
                        state = "chase";
                        agent.speed = 5f;
                    }
                }
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(eyes.position, playerTransform.position, Color.green);
        if (alive)
        {
            // idle
            if (state == "idle")
            {
                // pick random location to walk to
                Vector3 randomPosition = Random.insideUnitSphere * alertTime;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPosition, out navHit, 50f, NavMesh.AllAreas); 
                // finding a random spot from where the AI is standing on the NavMesh
                
                // search for player 
                if (highAlert)
                {
                    NavMesh.SamplePosition(playerTransform.position + randomPosition, out navHit, 50f, NavMesh.AllAreas); 
                    // finding a random spot from where the AI is standing on the NavMesh
                    // each time, lose awareness of player position
                    alertTime += 5f;

                    if (alertTime > 25f)
                    {
                        highAlert = false;
                        alertTime = 50f;
                        agent.speed = 3.5f;
                    }
                }
                
                agent.SetDestination(navHit.position); // setting the random position to the agent so it knows where to go. 
                state = "walk";
            }

            // walk
            if (state == "walk")
            {
                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending) 
                // If AIs remaining distance is less than stopping distance AND AI is not calculating where to walk...
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
                    //transform.Rotate(0f, 120f * Time.deltaTime, 0f);
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

                //lose sight of player
                float distance = Vector3.Distance(transform.position, playerTransform.position);
                if (distance > 10f) // UPDATE 10f value to inspector
                {
                    state = "find";
                }

                // TESTING ATTACK EVENT
                // kill the player
                else if (agent.remainingDistance <= agent.stoppingDistance + 1f && !agent.pathPending)
                {
                    //if(playerTransform.GetComponent<player>().alive)
                    //{
                        state = "kill";
                        //Player.GetComponent<player>().alive = false;
                        mainPlayer.GetComponent<PlayerMovement>().enabled = false;
                        mainPlayerMesh.enabled = false;
                        deathCam.SetActive(true);
                        deathCam.transform.position = Camera.main.transform.position;
                        deathCam.transform.rotation = Camera.main.transform.rotation;
                        Camera.main.gameObject.SetActive(false);
                        Invoke("reset", 1f);
                    //}
                }
                // TESTING ATTACK EVENT
            }

            //find
            if (state == "find")
            {
                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
                {
                    state = "search";
                    wait = 5f;
                    highAlert = true;
                    alertTime = 5f;
                    CheckSight();
                    // Change state to go back to idle after certain amount of time.
                }
                //animator.SetBool("isWalking", true);  ////////////////////////////
                //animator.SetBool("isRunning", false); /////////////////////////////
            }

            // TESTING ATTACK EVENT

            // KIll
            if (state == "kill")
            {
                deathCam.transform.position = Vector3.Slerp(deathCam.transform.position, deathCamPosition.position, 10f * Time.deltaTime);
                deathCam.transform.rotation = Quaternion.Slerp(deathCam.transform.rotation, deathCamPosition.rotation, 10f * Time.deltaTime);
                agent.SetDestination(deathCam.transform.position);
                agent.speed = 0f;

                //animator.SetBool("isWalking", false); /////////////////////////////////
                //animator.SetBool("isRunning", false); /////////////////////////////////
            }

            // TESTING ATTACK EVENT

            // agent.destination = playerTransform.position; // this gives the AI the players position and tells it to walk to the player
        }
        
        HandleAnimation();        
    }

    void HandleAnimation()
    {
        if (state == "walk")
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }

        if (state == "search")
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        if (state == "chase")
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", false);
        }

        if (state == "find")
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);
        }

        if (state == "kill")
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
    }

    //reset//
    void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
