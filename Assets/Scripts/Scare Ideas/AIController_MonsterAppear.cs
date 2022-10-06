using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_MonsterAppear : MonoBehaviour
{
    [SerializeField] private GameObject bloodAppear;
    [SerializeField] private GameObject monsterAppear;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private bool trig;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = true;
            // activate audio here
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
    }

    private void Update() 
    {
        if (trig == true)
        {
            bloodAppear.SetActive(true);
            audioSource.PlayOneShot(audioClip);
            StartCoroutine(MonsterAppear());
        }    
    }

    IEnumerator MonsterAppear()
    {
        yield return new WaitForSeconds(2.0f);
        monsterAppear.SetActive(true);
    }

}
