using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTouch : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;

    Vector3 startTouchPos;
    Vector3 endTouchPos;
 

    public void ActivatePanel()
    {
        // Activate the UI panel
        if (menuPanel != null)
        {
            menuPanel.SetActive(true);
        }
    }

    public void DeactivatePanel()
    {
        // Deactivate the UI panel
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Touch touch = Input.GetTouch(0);
            startTouchPos = Input.GetTouch(0).position;
            Debug.Log("Swipe began: "+ startTouchPos);

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //Touch touch = Input.GetTouch(0);
            endTouchPos = Input.GetTouch(0).position;
            Debug.Log("Swipe ended: "+ endTouchPos);

            if (endTouchPos.y > startTouchPos.y)
            {
                Debug.Log("Open Menu ");
             // ActivatePanel();
            }

            if (endTouchPos.y < startTouchPos.y)
            {
                Debug.Log("Close Menu ");
               // DeactivatePanel();
            }

        }
    }
}
