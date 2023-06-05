using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static bool isGameOver;
    int currentSceneIndex;
    int nextSceneIndex;
    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isGameOver = false;
        //  int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            ReloadGame();
        }
    }


    public void ReloadGame()
    {
        StartCoroutine(WaitAndLoad(1f, currentSceneIndex));
    }

    IEnumerator WaitAndLoad(float _delay, int _index)
    {    
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_index);
    }


}
