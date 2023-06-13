using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class DragEventTest : MonoBehaviour
{
    //Attach this script to the GameObject you would like to detect dragging on

    //Attach an Event Trigger component to the GameObject (Click the Add Component button and go to Event>Event Trigger)
    //Make sure the Camera you are using has a Physics Raycaster
    /// <summary>
    /// /(Click the Add Component button and go to Event>Physics Raycaster) so it can detect clicks on GameObjects.
    /// </summary>
   // [SerializeField] TextMeshProUGUI swipeDebug;
   //public string debugMessage;


   // public void DebugThis()
   // {
   //     swipeDebug.SetText(debugMessage);

   // }
    //void Start()
    //{
    //    EventTrigger trigger = GetComponent<EventTrigger>();

    //    if (trigger == null)
    //    {
    //        trigger = gameObject.AddComponent<EventTrigger>();
    //    }

    //    EventTrigger.Entry entry = new EventTrigger.Entry();
    //    entry.eventID = EventTriggerType.Drag;
    //    entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
    //    trigger.triggers.Add(entry);
    //}

    //public void OnDragDelegate(PointerEventData data)
    //{
    //    Debug.Log("Dragging.");
    //    swipeDebug.SetText("Dragging.");


    //    // Check if a button is being clicked
    //    if (EventSystem.current.IsPointerOverGameObject(data.pointerId))
    //    {
    //        Debug.Log(EventSystem.current.IsPointerOverGameObject(data.pointerId) + " IsPointerOverGameObject?");
    //        //   swipeDebug.SetText(EventSystem.current.IsPointerOverGameObject(data.pointerId).ToString() + " IsPointerOverGameObject?");
    //        swipeDebug.SetText(debugMessage);
    //        return; // Ignore swiping if a button is clicked

    //    }
    //    else
    //    {
    //        swipeDebug.SetText("Nothing to see here");
    //        Debug.Log("Nothing to see here");
    //    }


    //}


    //public void OnDragDetected(PointerEventData eventData)
    //{
    //    // Check if a button is being clicked
    //    if (EventSystem.current.IsPointerOverGameObject(eventData.pointerId))
    //    {
    //        Debug.Log(EventSystem.current.IsPointerOverGameObject(eventData.pointerId) + " IsPointerOverGameObject?");
    //        return; // Ignore swiping if a button is clicked
    //    }

    //    // Handle swiping here
    //    Debug.Log("Swipe Detected!");
    //}

}
