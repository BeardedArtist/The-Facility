using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private GameObject topLid;
    [SerializeField] private GameObject bottomLid;
    [SerializeField] private Animator blink_Anim;
    [SerializeField] private Animator blink_Anim_2;
    [SerializeField] bool isBlinking;
    [SerializeField] private float timer;

    private void Start() 
    {
        timer = Random.Range(30.0f, 50.0f);    
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = Random.Range(30.0f, 50.0f);
            isBlinking = true;
        }

        if (isBlinking == true)
        {
            blink_Anim.Play("TopLidBlink", 0, 0.25f);
            blink_Anim_2.Play("BottomLidBlink", 0, 0.25f);
            isBlinking = false;
        }
    }
}
