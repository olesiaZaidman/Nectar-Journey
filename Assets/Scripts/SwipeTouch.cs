using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwipeTouch : MonoBehaviour
{
    public abstract void SwipeInfoMenu();
    public abstract void ActivatePanel(GameObject _panel);
    public abstract void DeactivatePanel(GameObject _panel);

    public AudioEffects audioSFX;

    protected Touch theTouch;
    protected Vector3 startTouchPos;
    protected Vector3 endTouchPos;

    protected int pixelTapMax;
   
}
