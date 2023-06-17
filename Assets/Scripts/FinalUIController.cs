using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreFinalText;
    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreFinalText.SetText(ScoreManager.Score.ToString());
     //   Debug.Log("We updated score: " + ScoreManager.Score);
    }
}
