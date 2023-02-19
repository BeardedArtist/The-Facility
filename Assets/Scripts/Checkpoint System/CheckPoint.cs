using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Indicate if the checkpoint is activated.
    public bool activated = false;

    // List with all checkpoint objects in the scene
    public static GameObject[] CheckPointList;

    // Default starting position
    //public Vector3 startingPosition;

    private void Start() 
    {
        // We search all the checkpoints in the current scene
        CheckPointList = GameObject.FindGameObjectsWithTag("CheckPoint");    
    }


    // Activate the checkpoint
    private void ActivateCheckPoint()
    {
        // Deactivate all checkpoints in the scene
        foreach (GameObject cp in CheckPointList)
        {
            cp.GetComponent<CheckPoint>().activated = false;
            //cp.GetComponent<CheckPoint>().SetBool("Active", false);
        }
        // We activate the current checkpoint
        activated = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        // If the player passes through the checkpoint, we activate it.
        if (other.CompareTag("Player"))
        {
            ActivateCheckPoint();
        }    
    }


    // Get position of the last activated checkpoint
    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player dies without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(0,0,0);

        if (CheckPointList != null)
        {
            foreach (GameObject cp in CheckPointList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<CheckPoint>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }
        return result;
    }
}
