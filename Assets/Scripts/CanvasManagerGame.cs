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
    [SerializeField] GameObject hintPanel;
 
    MusicPlayer player;
    UIController uIController;

    bool showGameOver = false;
    bool isMenuOpen = false;
    bool isHintOpen = false;
    protected override bool IsMenuOpen
    {
        get { return isMenuOpen; }
        set { isMenuOpen = value; }
    }

    private void Awake()
    {
        uIController = FindObjectOfType<UIController>();
        audioSFX = FindObjectOfType<AudioEffects>();
        player = FindObjectOfType<MusicPlayer>();
    }
    void Start()
    {
        hintPanel.SetActive(false);
        gameOver.SetActive(false);
        menu.SetActive(false);
        gamePlay.SetActive(true);
        showGameOver = false;
        IsMenuOpen = false;
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

        if (audioSFX != null)
        {
            audioSFX.PlaySwipeSFX();
        }

        if (!GameData.isGameOver)
        {
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

        if (isHintOpen)
        {
            isHintOpen = false;
            hintPanel.SetActive(false);
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

    public void ShowHint()
    {
        isHintOpen = !isHintOpen;

        if (audioSFX != null)
        {
            audioSFX.PlaySwipeSFX();
        }

        if (!GameData.isGameOver)
        {
            imagePause.SetActive(!isHintOpen);
        }
        else        
        {
            if (IsMenuOpen)  
            {
                gameOver.SetActive(!isHintOpen);
            }
            else
            {
                gameOver.SetActive(true);
            }           
        }

        hintPanel.SetActive(isHintOpen);

        //if (isHintOpen)
        //{
        //    uIController.ShowNextHint();
        //}
    }

    public void NextHint()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        uIController.ShowNextHint();
    }

    public void PreviousHint()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        uIController.ShowPreviousHint();
    }
    public void CloseHints()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        isHintOpen = false;
        hintPanel.SetActive(false);

        if (!GameData.isGameOver)
        {
            imagePause.SetActive(true);
        }
        else
        {           
            gameOver.SetActive(true);
        }
    }


    public void OpenMenuInGameOver()
    {
        menu.SetActive(true);
        gameOver.SetActive(false);
        gamePlay.SetActive(false);
    }

}
