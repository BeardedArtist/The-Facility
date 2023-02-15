using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCardReveal : MonoBehaviour
{
    [SerializeField] private GameObject titleCard;
    [SerializeField] private GameObject AI_Final;
    private bool trig;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            titleCard.SetActive(true);
            AI_Final.SetActive(false);
            trig = true;
            //Time.timeScale = 0;
        }    
    }

    private void Update() 
    {
        if (trig == true)
        {
            if (Input.anyKeyDown)
            {
                StartCoroutine(ReturnToMainMenu());
            }
        }  
    }


    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
