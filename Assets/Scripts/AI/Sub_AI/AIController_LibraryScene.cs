using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIController_LibraryScene : MonoBehaviour
{
    public Transform playerTransform;
    public Transform eyes; // creating a transform for the 'eyes' cone in the AI.
    NavMeshAgent agent;

    private string state = "idle";
    private bool alive = true;
    private float wait = 0f;
    private bool highAlert = false;
    private float alertTime = 50f;
    public bool playerisHidingBadly = false;
    [SerializeField] public bool isAIActive = true;

    // ATTACK EVENT
    public GameObject deathCam;
    //public GameObject hidingCloset;
    public Transform deathCamPosition;
    public GameObject mainPlayer;
    public MeshRenderer mainPlayerMesh;
    //player Player;
    AIController_ServerSearch_Eyes Player;
    PlayerMovement playerMovement;
    // ATTACK EVENT

    // Decided points to walk to -->
    [SerializeField] private Transform[] wayPointList;

    [SerializeField] private int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;
    // Decided points to walk to <--

    // AUDIO FOR AI --> 
    [SerializeField] AudioSource audioSource;
    //[SerializeField] AudioClip audioClip;
    // AUDIO FOR AI <--


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GetComponent<AIController_ServerSearch_Eyes>();
        playerMovement = GetComponent<PlayerMovement>();

        if (audioSource != null & !audioSource.isPlaying)
        {
            audioSource.Play();
        }
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
                if (rayHit.collider.gameObject.tag == "Player")
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
                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
                {
                    currentWayPoint ++;

                    if (currentWayPoint < this.wayPointList.Length)
                    {
                        targetWayPoint = wayPointList[currentWayPoint];
                    }

                    else if (currentWayPoint >= this.wayPointList.Length)
                    {
                        Destroy(gameObject);
                        isAIActive = false;
                    }
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
                float distance = Vector3.Distance(transform.position, playerTransform.position);

                if (distance < 10f)
                {
                    agent.destination = playerTransform.position;

                    //TEST
                    if (distance < 3f)
                    {
                        state = "kill";
                        StopAI();
                        deathCam.SetActive(true);
                        deathCam.transform.position = Camera.main.transform.position;
                        deathCam.transform.rotation = Camera.main.transform.rotation;
                        Camera.main.gameObject.SetActive(false);
                        mainPlayer.GetComponent<PlayerMovement>().enabled = false;
                        mainPlayerMesh.enabled = false;
                        Invoke("reset", 1f);
                    }
                    //TEST
                }

                //lose sight of player             
                else if (distance > 11f)
                {
                    state = "find";
                }

                // TESTING ATTACK EVENT
                // kill the player

                // else if (agent.remainingDistance <= agent.stoppingDistance + 1f && !agent.pathPending)
                // {
                //     state = "kill";
                //     agent.isStopped = true;
                //     deathCam.SetActive(true);
                //     deathCam.transform.position = Camera.main.transform.position;
                //     deathCam.transform.rotation = Camera.main.transform.rotation;
                //     Camera.main.gameObject.SetActive(false);
                //     mainPlayer.GetComponent<PlayerMovement>().enabled = false;
                //     mainPlayerMesh.enabled = false;
                //     Invoke("reset", 1f);
                // }
                // TESTING ATTACK EVENT
            }

            // TEST --> If player hides during chase
            if (state == "chase" && playerisHidingBadly == true)
            {
                if (agent.remainingDistance <= agent.stoppingDistance + 5f && !agent.pathPending)
                {
                    agent.destination = playerTransform.position;
                    //hidingCloset.SetActive(false);
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
                //agent.SetDestination(deathCam.transform.position);
                agent.SetDestination(agent.transform.position);
            }

            // TESTING ATTACK EVENT
        }
    }

    //reset//
    void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void StopAI()
    {
        agent.isStopped = true;
        agent.speed = 0f;
        agent.acceleration = 0f;
        agent.angularSpeed = 0f;
    }
}
