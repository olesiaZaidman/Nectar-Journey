using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    AudioSource audioS;
    void Awake()
    {
        audioS = GetComponent<AudioSource>();    
    }


    void Update()
    {
        audioS.volume = AudioEffects.gameVolume;
    }
}
