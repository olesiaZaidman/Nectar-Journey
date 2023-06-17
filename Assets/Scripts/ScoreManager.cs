using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    static int score;
    static int scoreAtLevelStart;
    public static int Score { get { return score; } }

    static ScoreManager instance;

    public ScoreManager GetScoreManagerInstance()
    { return instance; }

    void Awake()
    {
        ManageSingleton();

        //        ResetScore();

    }
    void Start()
    {
      
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

    public static void ResetScore()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            score = 0;
        }
    }

    public static void SaveScoreAtLevelStart()
    {
        scoreAtLevelStart = score;
        Debug.Log("scoreAtLevelStart: " + scoreAtLevelStart);
    }

    public static void ResetScoreOnReloadLevel() //we call it on ReloadGame() in SceneLoadManager
    {
        score = scoreAtLevelStart;
    }

    public static void IncreaseScore()
    {
        score += 10;
    }

    public static void SaveScore(int _i)
    {
        if (_i > score)
        { score = _i; }
    }

}
