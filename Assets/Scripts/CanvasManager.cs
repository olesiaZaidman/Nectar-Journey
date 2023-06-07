using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract  class CanvasManager : MonoBehaviour
{
    public abstract void OpenMenu();
    public abstract void AudioSettings();
    protected abstract bool IsMenuOpen { get; set; }

    public AudioEffects audioSFX;
    public GameObject menu;

 

}
