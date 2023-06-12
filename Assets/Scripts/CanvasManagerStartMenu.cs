using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CanvasManagerStartMenu : CanvasManager
{
   // bool isMenuOpen = false;

    [SerializeField] GameObject credits;
    [SerializeField] GameObject gamePlay;
    [SerializeField] GameObject startMenu;

    [SerializeField] ParticleSystem snowFX;
    //protected override bool IsMenuOpen
    //{
    //    get { return isMenuOpen; }
    //    set { isMenuOpen = value; }
    //}

    public static bool isCreditsOpen = false;
    public static bool isMenuOpen = false;

    void Awake()
    {
        startMenu.SetActive(true);
        credits.SetActive(false);
        menu.SetActive(false);
        isMenuOpen = false;
    }

    void Start()
    {
        audioSFX = FindObjectOfType<AudioEffects>();
        snowFX.Play();
    }

    public override void OpenMenu()
    {
        isMenuOpen = !isMenuOpen;

        menu.SetActive(isMenuOpen);

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
        if (!isCreditsOpen)
        {
            isCreditsOpen = true;
            credits.SetActive(true);
            startMenu.SetActive(false);
            isMenuOpen = false;
            menu.SetActive(isMenuOpen);
        }
    }

    public override void AudioSettings()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }

        audioSFX.MuteAudioCheck();

    }


    public void BackToMenu()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        if (isCreditsOpen)
        {
            isCreditsOpen = false;
            credits.SetActive(false);

            startMenu.SetActive(true);
        }


      //  snowFX.Play();
    }
}
