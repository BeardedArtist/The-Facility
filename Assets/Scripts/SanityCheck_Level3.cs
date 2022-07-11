using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityCheck_Level3 : MonoBehaviour
{
    public Sanity sanity;

    public GameObject sanityLevel3_Appear;
    public GameObject sanityLevel3_Disappear;
    public GameObject sanityLevel3_UI_Appear;
    public GameObject completeBlackout_Anim;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && sanity.sanityPercentage >= 45f)
        {
            completeBlackout_Anim.SetActive(true);
            audioSource.PlayOneShot(audioClip);
            sanityLevel3_Appear.SetActive(true);
            sanityLevel3_UI_Appear.SetActive(true);
            sanityLevel3_Disappear.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
