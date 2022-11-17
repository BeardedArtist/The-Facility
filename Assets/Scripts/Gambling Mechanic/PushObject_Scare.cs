using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject_Scare : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;

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
            Debug.Log("Crashed");
            audioSource.PlayOneShot(audioClip);
        }    
    }

    private void Update() {
        if (Input.GetKey(KeyCode.P))
        {
            rb.AddForce(0 , 0, thrust, ForceMode.Impulse);    
        }
    }
}
