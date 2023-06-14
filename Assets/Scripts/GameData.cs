using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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


    static float levelDifficultyMax;
    public static float LevelDifficultyMax { get { return levelDifficultyMax; } }

    static float levelDifficulty;
    public static float LevelDifficulty { get { return levelDifficulty; } }

    static GameData instance;

    public GameData GetGameDataInstance()
    { return instance; }

    public static void IncreaseLevelDifficulty()
    {
        float deltaDiff = 0.1f;

        levelDifficulty += deltaDiff;
        levelDifficulty = Mathf.Clamp(levelDifficulty, 0f, LevelDifficultyMax);

        if (LevelDifficulty >= LevelDifficultyMax)
        {
            FindObjectOfType<SceneLoadManager>().LoadNextScene();
        }
    }
    public static void SetLevelDifficulty()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        float startLevelDiff = 0.2f;


        if (currentSceneIndex == 1)
        { 
            levelDifficultyMax = 0.5f;
        }

        if (currentSceneIndex == 2)
        {
            levelDifficultyMax = 0.5f; 
        }

        if (currentSceneIndex == 3)
        {
            levelDifficultyMax = 0.5f; 
        }

        levelDifficulty = startLevelDiff;
        levelDifficulty = Mathf.Clamp(levelDifficulty, 0f, LevelDifficultyMax);

        Debug.Log("Current Level: "+ currentSceneIndex+" "+"Current difficulty Max: "+ levelDifficultyMax);
    }
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
