using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyEffectFlash : MonoBehaviour
{
    private Animation anim;
    private bool Trig;
    public GameObject playerEyes;
    public GameObject reflectionAnim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Trig = true;

        if (Trig == true && other.tag == "Flashlight Eyes")
        {
                reflectionAnim.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Trig = false;
        reflectionAnim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
