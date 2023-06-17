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

    void Awake()
    {
        ManageSingleton();

        SetPlayerHPToMax();
        ResetScore();

        isGameOver = false;
        isAudioOn = true;
        isGameFreeze = false;
        //Time.timeScale = 1;

    }

    public static bool WinLevelCheck()
    {
        if (LevelDifficulty >= LevelDifficultyMax)
        {
            return true;
        }
        return false;
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
    }


    public static void IncreaseLevelDifficulty()
    {
        float deltaDiff = 0.1f;

        levelDifficulty += deltaDiff;
        levelDifficulty = Mathf.Clamp(levelDifficulty, 0f, LevelDifficultyMax);

        //if (WinLevelCheck())
        //{
        //    LoadNextSceneOnWinLevel();
        //}
    }

    //static void LoadNextSceneOnWinLevel()
    //{
    //    instance.StartCoroutine(LoadNextSceneOnWinLevelCheck());
    //}

    //static IEnumerator LoadNextSceneOnWinLevelCheck()
    //{
    //    SceneLoadManager sceneLoadManager = FindObjectOfType<SceneLoadManager>();

    //    yield return new WaitForSeconds(1f);


    //    if (sceneLoadManager != null)
    //    {
    //        sceneLoadManager.LoadNextScene();
    //    }
    //}

    public static void ResetScore()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            score = 0;
        }
    }


    public static void SetLevelDifficulty()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;


        float[] startLevelDifficulties = new float[sceneCount - 1]; //= { 0.2f, 0.3f, 0.4f };
        startLevelDifficulties[0] = 0.2f;
        startLevelDifficulties[1] = 0.3f;
        startLevelDifficulties[2] = 0.3f;

        float[] levelDifficultyMaxValues = new float[sceneCount - 1];//{ 0.6f, 0.7f, 0.9f };
        levelDifficultyMaxValues[0] = 0.3f; // 0.7f;
        levelDifficultyMaxValues[1] = 0.4f; // 0.8f;
        levelDifficultyMaxValues[2] = 0.4f; // 0.9f;



        Debug.Log("sceneCountInBuildSettings: " + sceneCount);

        if (currentSceneIndex >= 1 && currentSceneIndex < sceneCount)
        {
            int index = currentSceneIndex - 1;

            float startLevelDiff = startLevelDifficulties[index];
            levelDifficultyMax = levelDifficultyMaxValues[index];  //  float levelDifficultyMax = levelDifficultyMaxValues[index];

            levelDifficulty = Mathf.Clamp(startLevelDiff, 0f, LevelDifficultyMax);

            Debug.Log("Current Level: " + currentSceneIndex + " Current difficulty Max: " + LevelDifficultyMax);
        }
        else
        {
            Debug.Log("Invalid scene index for setting level difficulty");
        }

        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //float startLevelDiff;


        //if (currentSceneIndex == 1)
        //{
        //    startLevelDiff = 0.2f;
        //    levelDifficultyMax = 0.6f;
        //    levelDifficulty = startLevelDiff;
        //}

        //if (currentSceneIndex == 2)
        //{
        //    startLevelDiff = 0.3f;
        //    levelDifficultyMax = 0.7f;
        //    levelDifficulty = startLevelDiff;
        //}

        //if (currentSceneIndex == 3)
        //{
        //    startLevelDiff = 0.4f;
        //    levelDifficultyMax = 0.9f;
        //    levelDifficulty = startLevelDiff;
        //}

        //levelDifficulty = Mathf.Clamp(levelDifficulty, 0f, LevelDifficultyMax);

        //Debug.Log("Current Level: "+ currentSceneIndex+" "+"Current difficulty Max: "+ levelDifficultyMax);
    }

    public static void IncreasePlayerHP(int _i)
    {
        playerHP += _i;
        playerHP = Mathf.Clamp(playerHP, 0, playerMaxHP);
    }


    public static void SetPlayerHPToMax()
    {
        playerHP = playerMaxHP;
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
