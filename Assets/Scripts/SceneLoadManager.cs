using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class SceneLoadManager : MonoBehaviour
{
    public UnityEvent startGame;

    int currentSceneIndex;
    AudioEffects audioSFX;

    [SerializeField] GameObject uiParticles;

    public Animator sceneTransition;
 //  public Animator sceneStartCircleTransition;

    bool isNext = false; 

    void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        audioSFX = FindObjectOfType<AudioEffects>();
    }

    private void Start()
    {
        PlayStartSceneSound();
        ScoreManager.SaveScoreAtLevelStart();
    }




    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //Input.GetKey(KeyCode.Space)
        {
            QuitGame();
            Debug.Log("Quit game");
        }

        if (Input.GetKey(KeyCode.N) && !isNext) //Input.GetKey(KeyCode.Space)
        {
            isNext = true;
            LoadNextScene();
        }

       
    }
    public void ReloadGame()
    {

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        ScoreManager.ResetScoreOnReloadLevel();
        StartCoroutine(WaitAndLoad(1f, currentSceneIndex));


    }

    public void QuitGame()
    {

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        Application.Quit();
    }


    public void LoadScene(int _sceneNumber)
    {
        float _delay = 0.15f;
        // Debug.Log("Clicked");
        if (Time.timeScale == 0)
        { Time.timeScale = 1; }

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        //   PlayStartcrossFadeAnimation();
        ScoreManager.ResetScoreIfCertainScene(_sceneNumber);
        StartCoroutine(WaitAndLoad(_delay, _sceneNumber));

    }


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

      float _delay = 0.15f;
        //Debug.Log("Clicked");
        if (Time.timeScale == 0)
        { Time.timeScale = 1; }

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }

        //  PlayStartcrossFadeAnimation();
        StartCoroutine(WaitAndLoad(_delay, nextSceneIndex));

    }


    public void LoadNextSceneOnWinLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        float _delay = 1f;
        //Debug.Log("Clicked");
        if (Time.timeScale == 0)
        { Time.timeScale = 1; }

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }

        //  PlayStartcrossFadeAnimation();
        StartCoroutine(WaitAndLoad(_delay, nextSceneIndex));

    }




    public void StartGame()
    {
        float _delay = 0.1f;
        int _sceneId = 1;
        Debug.Log("Clicked");

        if (Time.timeScale == 0)
        { Time.timeScale = 1; }

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        startGame.Invoke();

        //  PlayStartcrossFadeAnimation();
        StartCoroutine(WaitAndLoad(_delay, _sceneId));

    }

    public void LoadGame()
    {
        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }

        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        StartCoroutine(WaitAndLoad(1f, nextSceneIndex));
    }

    IEnumerator WaitAndLoad(float _delay, int _index)
    {
        PlayStartcrossFadeAnimation();
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadSceneAsync(_index);
        //  SceneManager.LoadScene(_index);
    }
    void PlayStartcrossFadeAnimation()
    {
        if (sceneTransition != null)
        { 
            sceneTransition.SetTrigger("Start");
        }

    }

    //void PlayCircleAnimationAtStartIfNeeded()
    //{
    //    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    //    if (sceneStartCircleTransition != null)
    //    {
    //        if (currentSceneIndex == 1 && audioSFX != null)
    //        {
    //            audioSFX.PlayNectarRefillCollectionSFX();
    //        }


    //        if (currentSceneIndex > 1 && audioSFX != null)
    //        {
    //            sceneStartCircleTransition.SetTrigger("Start");
    //            audioSFX.PlayNectarRefillCollectionSFX();
    //        }

    //    }

        void PlayStartSceneSound()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentSceneIndex > 0 && audioSFX != null)
            {
                audioSFX.PlayNectarRefillCollectionSFX();
            }

        }
  
}
