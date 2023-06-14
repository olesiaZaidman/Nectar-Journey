using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SwipeTouchGame : SwipeTouchStart
{
    //[SerializeField] GameObject gamePanelGame;
    //[SerializeField] GameObject menuOnPausePanelGame;

    //[SerializeField] TextMeshProUGUI swipeDebug;
    //private string direction;
    //void Start()
    //{
    //    audioSFX = FindObjectOfType<AudioEffects>();
    //    pixelTapMax = 30;
    //}

    //public override void SwipeInfoMenu()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        theTouch = Input.GetTouch(0);

    //        if (theTouch.phase == TouchPhase.Began)
    //        {
    //            startTouchPos = theTouch.position;
    //            Debug.Log("Swipe began: " + startTouchPos);
    //        }


    //        else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
    //        {
    //            endTouchPos = theTouch.position;

    //            float x = endTouchPos.x - startTouchPos.x;
    //            float y = endTouchPos.y - startTouchPos.y;

    //            if (Mathf.Abs(x) < pixelTapMax && Mathf.Abs(y) < pixelTapMax)
    //            {
    //                  direction = "Tapped";
    //            }

    //            else if (Mathf.Abs(x) > Mathf.Abs(y))
    //            {
    //                //   direction = x > 0 ? "Right" : "Left";

    //                if (x > 0)
    //                {
    //                     direction = "Right";

    //                }
    //                else if (x < 0)
    //                {
    //                     direction = "Left";
    //                }
    //            }

    //            else
    //            {
    //                //   direction = y > 0 ? "Up" : "Down";

    //                if (y > 0)
    //                {
    //                       direction = "Up";

    //                    if (audioSFX != null && !CanvasManagerGame.isMenuOnPauseOpen)
    //                    {
    //                        audioSFX.PlaySwipeSFX();
    //                    }
    //                    CanvasManagerGame.isMenuOnPauseOpen = true;
    //                   // ActivatePanel(menuOnPausePanelGame);
    //                  //  DeactivatePanel(gamePanelGame);


    //                }
    //                else
    //                {
    //                     direction = "Down";
    //                    if (audioSFX != null && CanvasManagerGame.isMenuOnPauseOpen)
    //                    {
    //                        audioSFX.PlaySwipeSFX();
    //                    }
    //                    CanvasManagerGame.isMenuOnPauseOpen = false;
    //                  //  DeactivatePanel(menuOnPausePanelGame);
    //                   // ActivatePanel(gamePanelGame);

    //                }
    //            }
    //        }
    //    }

    //    //   Debug.Log(direction);
    //    swipeDebug.SetText(direction);
    //}


    //void Update()
    //{
    //    SwipeInfoMenu();
    //}
}
