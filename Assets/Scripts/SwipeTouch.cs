using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwipeTouch : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject mainPanel;
    Vector3 startTouchPos;
    Vector3 endTouchPos;

    private Touch theTouch;

  //  private string direction;

 //   [SerializeField] TextMeshProUGUI swipeDebug;
    AudioEffects audioSFX;

    int pixelTapMax = 30;
    void Start()
    {
        audioSFX = FindObjectOfType<AudioEffects>();
    }

    public void ActivatePanel(GameObject _panel)
    {
        //if (audioSFX != null)
        //{
        //    audioSFX.PlaySwipeSFX();
        //}
        // Activate the UI panel
        if (_panel != null)
        {
            _panel.SetActive(true);
        }
    }

    public void DeactivatePanel(GameObject _panel)
    {
       
        // Deactivate the UI panel
        if (_panel != null)
        {
            _panel.SetActive(false);
        }
    }

    void SwipeInfoMenu()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                startTouchPos = theTouch.position;
                Debug.Log("Swipe began: " + startTouchPos);
            }


            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                endTouchPos = theTouch.position;

                float x = endTouchPos.x - startTouchPos.x;
                float y = endTouchPos.y - startTouchPos.y;

                if (Mathf.Abs(x) < pixelTapMax && Mathf.Abs(y) < pixelTapMax)
                {
                  //  direction = "Tapped";
                }

                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    //   direction = x > 0 ? "Right" : "Left";

                    if (x > 0)
                    {
                     //   direction = "Right";
                        if (audioSFX != null && !CanvasManagerStartMenu.isCreditsOpen)
                        {
                            audioSFX.PlaySwipeSFX();
                        }
                        CanvasManagerStartMenu.isCreditsOpen = true;
                        ActivatePanel(creditsPanel);
                        DeactivatePanel(mainPanel);
    
                    }
                    else if (x < 0)
                    {
                      //  direction = "Left";
                        if (audioSFX != null && CanvasManagerStartMenu.isCreditsOpen)
                        {
                            audioSFX.PlaySwipeSFX();
                        }
                        CanvasManagerStartMenu.isCreditsOpen = false;
                        DeactivatePanel(creditsPanel);
                        ActivatePanel(mainPanel);

                    }
                }

                else
                {
                    //   direction = y > 0 ? "Up" : "Down";


                    if (y > 0)
                    {
                    //    direction = "Up";
                        if (audioSFX != null && !CanvasManagerStartMenu.isMenuOpen)
                        {
                            audioSFX.PlaySwipeSFX();
                        }
                        CanvasManagerStartMenu.isMenuOpen = true;
                        ActivatePanel(menuPanel);


                    }
                    else
                    {
                        if (audioSFX != null && CanvasManagerStartMenu.isMenuOpen)
                        {
                            audioSFX.PlaySwipeSFX();
                        }
                        CanvasManagerStartMenu.isMenuOpen = false;
                      //  direction = "Down";
                        DeactivatePanel(menuPanel);

                    }
                }
            }
        }

     //   Debug.Log(direction);
      //  swipeDebug.SetText(direction);
    }

 
    void Update()
    {
        SwipeInfoMenu();
    }
 
  

}
