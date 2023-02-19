using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodAnimation : MonoBehaviour
{
    // Animator References
    [SerializeField] private Animator bloodRiseBathroomSink_Anim;
    [SerializeField] private Animator bloodRiseBathroom_Anim;

    public void BloodRiseAnimation_1_BathroomSink()
    {
        bloodRiseBathroomSink_Anim.Play("BloodPool_RiseInSink", 0, 0);
    }

    public void BloodRiseAnimation_2_BathroomRoom()
    {
        StartCoroutine(BloodRiseInRoom());
    }

    IEnumerator BloodRiseInRoom()
    {
        yield return new WaitForSeconds(2.0f);
        bloodRiseBathroom_Anim.Play("BloodPool_RiseRoom", 0, 0);
    }
}
