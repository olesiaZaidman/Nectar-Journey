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

    [SerializeField] TextMeshProUGUI hintNumber;
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
        SetUpHint();
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

    void SetUpHint()
    {
       int i = hintsManager.GetCurrentIndex() + 1;
     hintNumber.SetText(i.ToString());
        hintHeaderText.SetText(hintsManager.GetCurrentHintHeader());
        hintText.SetText(hintsManager.GetCurrentHint());
    }
    public void ShowNextHint()
    {
        hintsManager.PromoteIndexArray();
        SetUpHint();
    }

    public void ShowPreviousHint()
    {
        hintsManager.DemoteIndexArray();
        SetUpHint();
    }
}
