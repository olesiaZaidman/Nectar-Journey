using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract  class CanvasManager : MonoBehaviour
{
    public abstract void OpenMenu();
    protected abstract bool IsMenuOpen { get; set; }
    protected abstract bool IsAudioMute{ get; set; }
    public AudioEffects audioSFX;
    public GameObject menu;

    void Start()
    {
        audioSFX = FindObjectOfType<AudioEffects>();
        menu.SetActive(false);
    }

}
