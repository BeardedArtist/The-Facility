using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf_Block : MonoBehaviour
{
    [SerializeField] private Animator bookshelfBlock_Anim;
    [SerializeField] private Animator bookshelfBlock_Anim2;
    private bool trig;
    private bool hasAnimationPlayed = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            trig = true;
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        trig = false;    
    }

    private void Update() 
    {
        if (trig == true && hasAnimationPlayed == false)
        {
            bookshelfBlock_Anim.Play("MovingBookshelf_1", 0, 0);
            bookshelfBlock_Anim2.Play("MovingBookshelf_2", 0, 0);
            hasAnimationPlayed = true;
        }    
    }
}
