using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ChangeTextColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI textToChangeColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        textToChangeColor.color = Color.red;
        Debug.Log("Mouse detected");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textToChangeColor.color = Color.white;
    }
}
