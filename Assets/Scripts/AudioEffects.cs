using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    static AudioEffects instance;

    public AudioEffects GetAudioPlayerInstance()
    { return instance; }

    [Header("UI")]
    [SerializeField] AudioClip click;
    [SerializeField] AudioClip swipe;
    [SerializeField] AudioClip tap;
    [SerializeField] AudioClip sceneLoaded;
    [SerializeField][Range(0f, 1f)] float uiVolume;

    [Header("Game")]
    [SerializeField] AudioClip dieSFX;
    [SerializeField] AudioClip nectarCollectSFX;
    [SerializeField] AudioClip finishSFX;
    [SerializeField][Range(0f, 1f)] float gameFxVolume;

  //  AudioSource audioSource;

    void Awake()
    {
        ManageSingleton();
      //  audioSource = GetComponent<AudioSource>();  
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #region UI

    public void PlayClickSFX()
    {
        PlaySFXClip(click, uiVolume);
    }

    public void PlayTapSFX()
    {
        PlaySFXClip(tap, uiVolume);
    }

    public void PlaySwipeSFX()
    {
        PlaySFXClip(swipe, uiVolume);
    }
    public void PlaySceneLoadedSFX()
    {
        PlaySFXClip(sceneLoaded, uiVolume);
    }
    #endregion

    #region Game
    public void PlayDieSFX()
    {
        PlaySFXClip(dieSFX, gameFxVolume);
    }

    public void PlayFinishSFX()
    {
        PlaySFXClip(finishSFX, gameFxVolume);
    }

    public void PlayNectarCollectionSFX()
    {
        PlaySFXClip(nectarCollectSFX, gameFxVolume);
    }

    #endregion


    void PlaySFXClip(AudioClip _clip, float _volume)
    {
       Vector3 _cameraPosition = Camera.main.transform.position;

        if (_clip != null)
        {

        AudioSource.PlayClipAtPoint(_clip, _cameraPosition, _volume);          // OR  audioSource.PlayOneShot(_clip, _volume);
        }
    }
}
