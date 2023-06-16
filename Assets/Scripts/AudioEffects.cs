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
    [SerializeField] AudioClip gamePause;
    [SerializeField] AudioClip hintsOpen;
    [SerializeField] AudioClip nextHintButtonClick;
    //  [SerializeField][Range(0f, 1f)] float uiVolume;

    [Header("Game")]
    [SerializeField] AudioClip dieSFX;
    [SerializeField] AudioClip groundTouchSFX;
    [SerializeField] AudioClip nectarCollectSFX;
    [SerializeField] AudioClip nectarRefillCollectSFX;
    [SerializeField] AudioClip finishSFX;
  //  [SerializeField][Range(0f, 1f)] float gameFxVolume;

   public static float gameVolume = 0.8f;

    float volumeSFXmodifier = 0.2f;
    public static bool isMute = false;
    public void MuteAudioCheck()
    {
        isMute = !isMute;
        if (isMute)
        {
            gameVolume = 0f;
        }
        else
        {
            gameVolume = 0.8f;
        }

        Debug.Log("isMute: "+ isMute);
    }


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
        PlaySFXClip(click, gameVolume - volumeSFXmodifier);
    }

    public void PlayPauseSFX()
    {
        PlaySFXClip(gamePause, gameVolume - volumeSFXmodifier);
    }

    public void PlaySwipeSFX()
    {
        PlaySFXClip(swipe, gameVolume - (volumeSFXmodifier * 2));
    }
    public void PlayHintsOpenSFX()
    {
        PlaySFXClip(hintsOpen, gameVolume - (volumeSFXmodifier * 2));
    }

    public void PlayNextHintButtonClickSFX()
    {
        PlaySFXClip(nextHintButtonClick, gameVolume - (volumeSFXmodifier * 2));
    }
    #endregion

    #region Game
    public void PlayDieSFX()
    {
        PlaySFXClip(dieSFX, gameVolume - volumeSFXmodifier);
    }

    public void PlayFinishSFX()
    {
        PlaySFXClip(finishSFX, gameVolume - volumeSFXmodifier);
    }

    public void PlayNectarCollectionSFX()
    {
        PlaySFXClip(nectarCollectSFX, gameVolume- (volumeSFXmodifier*3));
    }

    public void PlayNectarRefillCollectionSFX()
    {
        PlaySFXClip(nectarRefillCollectSFX, gameVolume - (volumeSFXmodifier * 2));
    }



    public void PlayGroundTouchSFX()
    {
        PlaySFXClip(groundTouchSFX, gameVolume - (volumeSFXmodifier * 2));
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
