using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CanvasManagerGame : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gamePlay;
    [SerializeField] GameObject menu;
    bool showGameOver = false;
    AudioEffects audioSFX;
    MusicPlayer player;

    bool isMenuOpen = false;

    void Start()
    {
        audioSFX = FindObjectOfType<AudioEffects>();
        player = FindObjectOfType<MusicPlayer>();
        gameOver.SetActive(false);
        menu.SetActive(false);
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



    public void OpenMenu()
    {

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }

        isMenuOpen = !isMenuOpen;

        menu.SetActive(isMenuOpen);

        if (!GameData.isGameOver)
        {
            gamePlay.SetActive(!isMenuOpen);

            if (isMenuOpen)
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





        //if (GameData.isGameOver)
        //{
        //    gameOver.SetActive(false);
        //}
    }

    public void OpenMenuInGameOver()
    {
        menu.SetActive(true);
        gameOver.SetActive(false);
        gamePlay.SetActive(false);
    }

}
