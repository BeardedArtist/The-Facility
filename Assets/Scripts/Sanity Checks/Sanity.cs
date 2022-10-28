using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    public Text sanityText;
    public float sanityPercentage;

    private void Start() 
    {
        sanityPercentage = 0f;    
    }

    public void PlayerSanity(int percentage)
    {
        sanityPercentage += percentage * Time.deltaTime;
        sanityText.text = "Sanity %: " + sanityPercentage.ToString("f0");
    }
}
