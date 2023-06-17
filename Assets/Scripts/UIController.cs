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

 //   [SerializeField] GameObject sliderFX;
    Hints hintsManager;

    Color originalYellowcolor = new Color(1, 0.90463f, 0.5226415f, 1); //FFE785
    Color redcolor = new Color(1, 0.410962f, 0.3150943f, 1); //FF6950

    void Awake()
    {
        hintsManager = FindObjectOfType<Hints>();
      //  sliderFX.SetActive(false);
        fill.color = originalYellowcolor;   
    }

    void Start()
    {
        SetProgressBar();
      //  SetStartScore();
       UpdateScore();
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

       if(progressBar.value < GameData.PlayerMaxHP*0.5f)
        {
            fill.color = redcolor;
        }
        else
        {
            fill.color = originalYellowcolor;
        }
    }

    public void UpdateScore()
    {
        scoreText.SetText(ScoreManager.Score.ToString());
        scoreFinalText.SetText(ScoreManager.Score.ToString());

      //  Debug.Log("We updated score: " + ScoreManager.Score);
    }

    public void SetStartScore()
    {
      //  scoreFinalText.SetText(ScoreManager.Score.ToString());
        scoreText.SetText(ScoreManager.Score.ToString());

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
