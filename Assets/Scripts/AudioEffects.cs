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
  //  [SerializeField][Range(0f, 1f)] float uiVolume;

    [Header("Game")]
    [SerializeField] AudioClip dieSFX;
    [SerializeField] AudioClip nectarCollectSFX;
    [SerializeField] AudioClip finishSFX;
  //  [SerializeField][Range(0f, 1f)] float gameFxVolume;

   public static float gameVolume = 0.8f;

    public void MuteAudioCheck(bool _isMute)
    {
        if (_isMute)
        { gameVolume = 0f; }
        else gameVolume = 0.8f;

    }

    //public void UnmuteAudio(float _volume)
    //{
    //    gameVolume = _volume;
    //}


    void Awake()
    {
        ManageSingleton();
        gameVolume = 0.8f;
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
        PlaySFXClip(click, gameVolume);
    }

    public void PlayTapSFX()
    {
        PlaySFXClip(tap, gameVolume);
    }

    public void PlaySwipeSFX()
    {
        PlaySFXClip(swipe, gameVolume);
    }
    public void PlaySceneLoadedSFX()
    {
        PlaySFXClip(sceneLoaded, gameVolume);
    }
    #endregion

    #region Game
    public void PlayDieSFX()
    {
        PlaySFXClip(dieSFX, gameVolume);
    }

    public void PlayFinishSFX()
    {
        PlaySFXClip(finishSFX, gameVolume);
    }

    public void PlayNectarCollectionSFX()
    {
        PlaySFXClip(nectarCollectSFX, gameVolume);
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
