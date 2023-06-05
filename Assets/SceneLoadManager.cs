using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static bool isGameOver;
    int currentSceneIndex;
    int nextSceneIndex;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject gamePlayCanvas;
    [SerializeField] GameObject startCanvas;

    [SerializeField] GameObject player;
    [SerializeField] GameObject decor_grass;
    [SerializeField] GameObject decor_flowers;
    void Start()
    {
        gameOverCanvas.SetActive(false);
        gamePlayCanvas.SetActive(false);
       // player.SetActive(false);
    //    decor_grass.SetActive(false);
     //   decor_flowers.SetActive(true);

        gamePlayCanvas.SetActive(true);



        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isGameOver = false;
        //  int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverCanvas.SetActive(true);
            gamePlayCanvas.SetActive(false);
        }
    }

    public void StartLoadGame()
    {
        //GameData.isGameStarted = true;
        //if (GameData.isGameStarted)
        //{
        //    player.SetActive(true);
        //    decor_grass.SetActive(true);
        //    decor_flowers.SetActive(false);
        //    gamePlayCanvas.SetActive(true);
        //    startCanvas.SetActive(false);
        //    StartCoroutine(WaitAndLoad(1f, currentSceneIndex));
        //}

    }

    public void ReloadGame()
    {
        StartCoroutine(WaitAndLoad(1f, currentSceneIndex));
    }


    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad(1f, currentSceneIndex));
    }

    IEnumerator WaitAndLoad(float _delay, int _index)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_index);
    }


}
