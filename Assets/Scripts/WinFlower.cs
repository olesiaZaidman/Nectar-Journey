using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlower : MonoBehaviour
{
    AudioSource winLevelAudioSource;
    [SerializeField] AudioClip win;
    bool isWinLevel = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isWinLevel)
        {
            winLevelAudioSource = GetComponent<AudioSource>();
            isWinLevel = true;
            winLevelAudioSource.PlayOneShot(win, AudioEffects.gameVolume);
        }
    }
}
