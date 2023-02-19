using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerAnimation : MonoBehaviour
{
    public int lightMode;
    public GameObject florescentLight;

    // Update is called once per frame
    void Update()
    {
        if (lightMode == 0) // we don't have 0 animations, so it will play one of the animations.
        {
            StartCoroutine(AnimateLight());
        }
    }

    IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1,4);
        if (lightMode == 1)
        {
            florescentLight.GetComponent<Animation>().Play("FlorescentLightFlickering_Anim1");
        }
        if (lightMode == 2)
        {
            florescentLight.GetComponent<Animation>().Play("FlorescentLightFlickering_Anim2");
        }
        if (lightMode == 3)
        {
            florescentLight.GetComponent<Animation>().Play("FlorescentLightFlickering_Anim3");
        }

        yield return new WaitForSeconds(1f);
        lightMode = 0;
    }
}
