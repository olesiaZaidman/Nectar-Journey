using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    int currentSceneIndex;
    AudioEffects audioSFX;
    void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        audioSFX = FindObjectOfType<AudioEffects>();    
    }

    public void ReloadGame()
    {
        audioSFX.PlayClickSFX();
        StartCoroutine(WaitAndLoad(1f, currentSceneIndex));
    }

    public void QuitGame()
    {
        audioSFX.PlayClickSFX();
        Application.Quit(); 
    }

    public void LoadGame()
    {
        audioSFX.PlayClickSFX();
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        StartCoroutine(WaitAndLoad(1f, nextSceneIndex));
    }

    IEnumerator WaitAndLoad(float _delay, int _index)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_index);
    }

}
