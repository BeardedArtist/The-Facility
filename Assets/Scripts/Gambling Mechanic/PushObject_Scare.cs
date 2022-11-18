using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject_Scare : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;
    private bool hasAudioPlayed = false;

    [SerializeField] private GameObject BookshelfCollider;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Carpet")
        {
            if (!audioSource.isPlaying && hasAudioPlayed == false)
            {
                audioSource.PlayOneShot(audioClip);
            }
            
            StartCoroutine(isKinematic());
        }    
    }

    public void TriggerOneScare()
    {
        rb.AddForce(0 , 0, thrust, ForceMode.Impulse);
    }

    IEnumerator isKinematic()
    {
        yield return new WaitForSeconds(0.2f);
        rb.isKinematic = true;
    }
}
