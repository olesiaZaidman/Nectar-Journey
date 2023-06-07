using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData : MonoBehaviour
{
    static int playerHP;
    const int playerMaxHP = 100;
    static int score;

    public static bool isGameOver = false;
    public static bool isAudioOn = true;
    public static bool isGameFreeze = false;
    public static int PlayerHP { get { return playerHP; } }
    public static int Score { get { return score; } }
    public static int PlayerMaxHP { get { return playerMaxHP; } }



    static GameData instance;

    public GameData GetGameDataInstance()
    { return instance; }

    void Awake()
    {
        ManageSingleton();
       
        playerHP = 100;
        score = 0;

        isGameOver = false;
        isAudioOn = true;
        isGameFreeze = false;
        //Time.timeScale = 1;
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        if (playerHP <= 0)
        { 
            isGameOver = true;
        }
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
