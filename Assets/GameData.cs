using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData : MonoBehaviour
{
    static int playerHP;
    const int playerMaxHP = 100;
    static int score;


    public static bool isGameOver;
    public static int PlayerHP { get { return playerHP; } }

    public static int Score { get { return score; } }
    public static int PlayerMaxHP { get { return playerMaxHP; } }

    public static bool isGameStarted = false;



    void Awake()
    {
        playerHP = 100;
        isGameOver = false;
        score = 0;
        //Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        //if (isGameOver)
        //{ Time.timeScale = 0; }
    }

    public static void IncreasePlayerHP(int _i)
    {
        playerHP += _i;
        playerHP = Mathf.Clamp(playerHP, 0, playerMaxHP);
    }

    public static void DecreasePlayerHP(int _i)
    {
        playerHP -= _i;
        playerHP = Mathf.Clamp(playerHP, 0, playerMaxHP);
    }

    public static void IncreaseScore()
    {
        score += 10;

    }
}
