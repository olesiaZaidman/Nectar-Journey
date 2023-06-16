using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlower : MonoBehaviour
{

 //  [SerializeField] ParticleSystem winLevelNectarBoost;
    AudioSource winLevelAudioSource;
    [SerializeField] AudioClip win;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winLevelAudioSource = GetComponent<AudioSource>();
            winLevelAudioSource.PlayOneShot(win, AudioEffects.gameVolume);
          //  winLevelNectarBoost.Play();
        }
    }
}
