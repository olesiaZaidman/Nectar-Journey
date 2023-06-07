using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] Image fill;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreFinalText;

    [SerializeField] TextMeshProUGUI hintHeaderText;
    [SerializeField] TextMeshProUGUI hintText;
    Hints hintsManager;

    void Awake()
    {
        hintsManager = FindObjectOfType<Hints>();
    }

    void Start()
    {
        SetProgressBar();
        scoreFinalText.SetText(GameData.Score.ToString());
    }
    void SetProgressBar()
    {
        progressBar.maxValue = GameData.PlayerMaxHP;
        progressBar.value = GameData.PlayerHP; //minvalue GameData.PlayerHP
    }

   public void UpdateProgressBar()
    {
        progressBar.value = GameData.PlayerHP;
    }

    public void UpdateScore()
    {
        scoreText.SetText(GameData.Score.ToString());
        scoreFinalText.SetText(GameData.Score.ToString());
    }

    public void ShowNextHint()
    {
        hintHeaderText.SetText(hintsManager.ShowNextHintHeader());
        hintText.SetText(hintsManager.ShowNextHint());
    }
}
