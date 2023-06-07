using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Events;


public class ButtonWithImageSwitch : MonoBehaviour
{
    [SerializeField] Button button;
    Image buttonImage;
    [SerializeField] Sprite image1;
    [SerializeField] Sprite image2;
   // public UnityEvent onClickEvent;
    bool isImage1 = true;
    void Start()
    {
        buttonImage= button.GetComponent<Image>();
        isImage1 = true;
        buttonImage.sprite = image1;
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // Switch the source image
        if (isImage1)
        {
            buttonImage.sprite = image2;
        }
        else
        {
            buttonImage.sprite = image1;
        }

        isImage1 = !isImage1;

        // Call the function or raise the event
   //     onClickEvent.Invoke();
    }
}
