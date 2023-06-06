using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject gamePlayCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        gamePlayCanvas.SetActive(true);
    }

    void Update()
    {
        if (GameData.isGameOver)
        {
            gameOverCanvas.SetActive(true);
            gamePlayCanvas.SetActive(false);
        }
    }

}
