using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectToShow;
    public UnityEvent onPointerEnter;
    public UnityEvent onPointerExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered");
        onPointerEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited");
        onPointerExit.Invoke();    
    }

}
