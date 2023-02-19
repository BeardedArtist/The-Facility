using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIController_Chase : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent agent;

    [SerializeField] private string state = "chase";
    private float wait = 0f;
    private bool highAlert = false;
    private float alertTime = 50f;


    public GameObject deathCam;
    public Transform deathCamPosition;
    public GameObject mainPlayer;
    public MeshRenderer mainPlayerMesh;
    PlayerMovement playerMovement;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "chase")
        {
            agent.destination = playerTransform.position;

            if (agent.remainingDistance <= agent.stoppingDistance + 1f && !agent.pathPending)
            {
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

        if (state == "kill")
        {
            deathCam.transform.position = Vector3.Slerp(deathCam.transform.position, deathCamPosition.position, 10f * Time.deltaTime);
            deathCam.transform.rotation = Quaternion.Slerp(deathCam.transform.rotation, deathCamPosition.rotation, 10f * Time.deltaTime);
            agent.SetDestination(deathCam.transform.position);
            agent.speed = 0f;
        }

        HandleAnimation();
    }

    void reset() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }


    void HandleAnimation()
    {
        if (state == "chase")
        {
            animator.SetBool("isWalking", true);
        }
    }
}
