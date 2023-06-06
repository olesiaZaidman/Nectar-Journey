using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Input = UnityEngine.Input;

public class SceneLoadManager : MonoBehaviour
{
    int currentSceneIndex;
    AudioEffects audioSFX;
    void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        audioSFX = FindObjectOfType<AudioEffects>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //Input.GetKey(KeyCode.Space)
        {
            QuitGame();
            Debug.Log("Quit game");
        }
    }
    public void ReloadGame()
    {

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
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

    public void LoadStartMenuGame()
    {

        if (audioSFX != null)
        {
            audioSFX.PlayClickSFX();
        }
        StartCoroutine(WaitAndLoad(1f, 0));
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
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_index);
    }

}
