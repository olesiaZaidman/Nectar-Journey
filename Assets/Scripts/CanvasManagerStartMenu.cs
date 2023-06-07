using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CanvasManagerStartMenu : CanvasManager
{
    bool isMenuOpen = false;

    [SerializeField] GameObject credits;
    [SerializeField] GameObject gamePlay;
    [SerializeField] GameObject startMenu;

    [SerializeField] ParticleSystem snowFX;
    protected override bool IsMenuOpen
    {
        get { return isMenuOpen; }
        set { isMenuOpen = value; }
    }
    bool isAudioMute = false;
    protected override bool IsAudioMute
    {
        get { return isAudioMute; }
        set { isAudioMute = value; }
    }

    void Awake()
    {
        startMenu.SetActive(true);
        credits.SetActive(false);
        menu.SetActive(false);
        IsMenuOpen = false;
    }

    void Start()
    {
        audioSFX = FindObjectOfType<AudioEffects>();
        snowFX.Play();
    }

    public override void OpenMenu()
    {
        IsMenuOpen = !IsMenuOpen;

        menu.SetActive(IsMenuOpen);

        if (audioSFX != null)
        {
            audioSFX.PlaySwipeSFX();
        }
    }

    public void OpenCredits()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
      //  snowFX.Stop();
        credits.SetActive(true);
        startMenu.SetActive(false);
        IsMenuOpen = false;
        menu.SetActive(IsMenuOpen);
    }

    public void AudioSettings()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }

        IsAudioMute = !IsAudioMute;

        audioSFX.MuteAudioCheck(IsAudioMute);

    }


    public void BackToMenu()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        credits.SetActive(false);
        startMenu.SetActive(true);
      //  snowFX.Play();
    }
}
