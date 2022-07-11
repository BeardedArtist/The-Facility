using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityCheck : MonoBehaviour
{
    public Sanity sanity;

    public GameObject sanityLevel1_Appear;
    public GameObject sanityLevel1_Disappear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && sanity.sanityPercentage >= 20f)
        {
            Debug.Log("We can feel something strange in the air");
            sanityLevel1_Appear.SetActive(true);
            sanityLevel1_Disappear.SetActive(false);
            Destroy(gameObject);
        }    
    }
}
