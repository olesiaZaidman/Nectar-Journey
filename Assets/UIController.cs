using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] Image fill;

    void Start()
    {
        SetProgressBar();
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
}
