using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIController_ServerSearch : MonoBehaviour
{
    public Transform playerTransform;
    public Transform eyes; // creating a transform for the 'eyes' cone in the AI.
    NavMeshAgent agent;

    private string state = "idle";
    private bool alive = true;
    private float wait = 0f;
    private bool highAlert = false;
    private float alertTime = 50f;
    public bool playerisHidingBadly;

    // ATTACK EVENT
    public GameObject deathCam;
    public GameObject hidingCloset;
    public Transform deathCamPosition;
    public GameObject mainPlayer;
    public MeshRenderer mainPlayerMesh;
    player Player;
    PlayerMovement playerMovement;
    // ATTACK EVENT

    // Decided points to walk to -->
    [SerializeField] private Transform[] wayPointList;

    [SerializeField] private int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;
    // Decided points to walk to <--


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GetComponent<player>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Check if we can see player
    public void CheckSight()
    {
        if (alive)
        {
            RaycastHit rayHit;
            if (Physics.Linecast(eyes.position, playerTransform.position, out rayHit)) // check to see if the raycast intersects with anything
            {
                print ("hit " + rayHit.collider.gameObject.name);
                if (rayHit.collider.gameObject.name == "FirstPersonPlayer")
                {
                    print("hit " + rayHit.collider.gameObject.name);
                    // chase
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
                // decided points to walk to
                if (currentWayPoint < this.wayPointList.Length)
                {
                    if (targetWayPoint == null)
                    {
                        targetWayPoint = wayPointList[currentWayPoint];
                    }
                    agent.SetDestination(targetWayPoint.position);
                    state = "walk";
                }
                
            }

            // walk
            if (state == "walk")
            {
                // // rotate towards target
                // transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

                // // move towards target 
                // transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

                // if (transform.position == targetWayPoint.position)
                // {
                //     currentWayPoint ++;
                //     targetWayPoint = wayPointList[currentWayPoint];
                //     //-----
                //     state = "search";
                //     wait = 5f;
                // }

                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
                {
                    currentWayPoint ++;
                    targetWayPoint = wayPointList[currentWayPoint];
                    //-----
                    state = "search";
                    wait = 5f;
                }
            }

            // search
            if (state == "search")
            {
                if (wait > 0f)
                {
                    wait -= Time.deltaTime;
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
                if (distance > 10f)
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

            // TEST --> If player hides during chase
            if (state == "chase" && playerisHidingBadly == true)
            {
                if (agent.remainingDistance <= agent.stoppingDistance + 5f && !agent.pathPending)
                {
                    agent.destination = playerTransform.position;
                    hidingCloset.SetActive(false);
                    state = "kill";

                    mainPlayer.GetComponent<PlayerMovement>().enabled = false;
                    mainPlayerMesh.enabled = false;
                    deathCam.SetActive(true);
                    deathCam.transform.position = Camera.main.transform.position;
                    deathCam.transform.rotation = Camera.main.transform.rotation;
                    Camera.main.gameObject.SetActive(false);
                    Invoke("reset", 1f);
                }
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
                }
            }

            // TESTING ATTACK EVENT

            // KIll
            if (state == "kill")
            {
                deathCam.transform.position = Vector3.Slerp(deathCam.transform.position, deathCamPosition.position, 10f * Time.deltaTime);
                deathCam.transform.rotation = Quaternion.Slerp(deathCam.transform.rotation, deathCamPosition.rotation, 10f * Time.deltaTime);
                agent.SetDestination(deathCam.transform.position);
                agent.speed = 0f;
            }

            // TESTING ATTACK EVENT
        }
    }

    //reset//
    void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
