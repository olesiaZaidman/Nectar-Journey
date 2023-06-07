using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CanvasManagerGame : CanvasManager
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gamePlay;
   // [SerializeField] GameObject menu;

    [SerializeField] GameObject imagePause;
    bool showGameOver = false;
   
    MusicPlayer player;

    bool isMenuOpen = false;
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

    //  AudioEffects audioSFX;

    void Start()
    {
        audioSFX = FindObjectOfType<AudioEffects>();
        player = FindObjectOfType<MusicPlayer>();
        gameOver.SetActive(false);
      //  menu.SetActive(false);
        gamePlay.SetActive(true);
        showGameOver = false;
    }

    void Update()
    {
        if (GameData.isGameOver && !showGameOver)
        {
            player.StopMusic();

            if (audioSFX != null)
            {
                audioSFX.PlayClickSFX();
            }

            showGameOver = true;
            gameOver.SetActive(true);
            gamePlay.SetActive(false);
        }
    }



    public override void OpenMenu()
    {
        IsMenuOpen = !IsMenuOpen;

        menu.SetActive(IsMenuOpen);

        if (!GameData.isGameOver)
        {
            if (audioSFX != null)
            {
                audioSFX.PlaySwipeSFX();
            }


            gamePlay.SetActive(!IsMenuOpen);
            imagePause.SetActive(true);
            if (IsMenuOpen)
            {
                Time.timeScale = 0;
                GameData.isGameFreeze = true;
            }
            else
            {
                Time.timeScale = 1;
                GameData.isGameFreeze = false;
            }
        }

        else 
        {
            imagePause.SetActive(false); 
        }
    }

    public void OpenMenuInGameOver()
    {
        menu.SetActive(true);
        gameOver.SetActive(false);
        gamePlay.SetActive(false);
    }

}
