using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagerStartMenu : CanvasManager
{
   // bool isMenuOpen = false;

    [SerializeField] GameObject credits;

    [SerializeField] GameObject startMenu;

    [SerializeField] ParticleSystem snowFX;

    [SerializeField] GameObject loadingCanvas;
    [SerializeField] GameObject flowers;
    [SerializeField] GameObject gameMenuCanvas;
    [SerializeField] GameObject uiFX;
    //protected override bool IsMenuOpen
    //{
    //    get { return isMenuOpen; }
    //    set { isMenuOpen = value; }
    //}

    public static bool isCreditsOpen = false;
    public static bool isMenuOpen = false;


   public void OpenLoadingCanvas()
    {
        loadingCanvas.SetActive(true);
        gameMenuCanvas.SetActive(false);
        flowers.SetActive(false);
        uiFX.SetActive(false);
    }

    void OpenStartCanvas()
    {
        loadingCanvas.SetActive(false);
        gameMenuCanvas.SetActive(true);
        flowers.SetActive(true);
        uiFX.SetActive(true);
    }

    void Awake()
    {
        OpenStartCanvas();
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
