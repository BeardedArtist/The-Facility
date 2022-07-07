using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomalyEffect : MonoBehaviour
{
    private bool Trig;

    public GameObject playerHeadMovement;
    public GameObject playerBodyMovement;
    public Sanity playerSanity;
    public GameObject blackOutAnim;

    // Start is called before the first frame update
    void Start()
    {
        //playerSanity = GetComponent<Sanity>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Trig = true;

        if (Trig == true && other.tag == "Player")
        {
            //playerHeadMovement.GetComponent<MouseLook>().enabled = false;
            blackOutAnim.SetActive(true);
            StartCoroutine(DisablePlayer());
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Trig = false;

        if (Trig == false)
        {
            blackOutAnim.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player")
        {
            playerSanity.PlayerSanity(1);
        }    
    }

    IEnumerator DisablePlayer ()
    {
        playerHeadMovement.GetComponent<MouseLook>().enabled = false;
        playerBodyMovement.GetComponent<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(2f);

        playerHeadMovement.GetComponent<MouseLook>().enabled = true;
        playerBodyMovement.GetComponent<PlayerMovement>().enabled = true;

    }
}
