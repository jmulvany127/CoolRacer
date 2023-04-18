using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrackButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject HoverPanel;
    public GameObject defDes;


    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverPanel.SetActive(true);
        defDes.SetActive(false);        // set the default description off when hovering over button text
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverPanel.SetActive(false);
        defDes.SetActive(true);         // set the default description on when not hovering over button text
    }   
}
