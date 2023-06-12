using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickHandler : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // Handle the button click event here
        Debug.Log("Button Clicked!");
     //   swipeDebug.SetText("Button Clicked!");
    }
}
