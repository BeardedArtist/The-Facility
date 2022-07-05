using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomalyEffect : MonoBehaviour
{
    private bool Trig;

    public GameObject playerHeadMovement;

    public Text text;
    public int sanityPercentage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        Trig = true;

        if (Trig == true && other.tag == "Player")
        {
            playerHeadMovement.GetComponent<MouseLook>().enabled = false;

            sanityPercentage += 10;
            text.text = "Sanity %: " + sanityPercentage.ToString();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Trig = false;

        if (Trig == false)
        {
            playerHeadMovement.GetComponent<MouseLook>().enabled = true;
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Trig == true)
    //     {
    //         playerHeadMovement.GetComponent<MouseLook>().enabled = false;
    //     }

    //     else if (Trig == false)
    //     {
    //         playerHeadMovement.GetComponent<MouseLook>().enabled = true;
    //     }
    // }
}
