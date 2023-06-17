using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem nectarFX;
    [SerializeField] ParticleSystem dieFX;
    [SerializeField] ParticleSystem winLevelFX;


    public UnityEvent increaseHealthBar;
    public UnityEvent loadNextLevel;
    public UnityEvent finishGame;

    bool isEnergized = false;
    float groundPushMod = 1.5f;

    bool isDead = false;
    UIController uIController;
    AudioEffects audioSFX;
    // bool isPlayedSFX = false;
    PlayerController playerController;

    bool isWinLevel = false;
    void Awake()
    {
        uIController = FindObjectOfType<UIController>();
        audioSFX = FindObjectOfType<AudioEffects>();
        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    void Update()
    {
        if (GameData.isGameOver && !isDead)
        {
            isDead = true;
            HurtPlayer();
        }
    }

    void OnParticleCollision(GameObject other)  //OnParticleTrigger
    {
        //Particle
        if (other.gameObject.CompareTag("Hazard"))
        {
            //  !!! GameData.isGameOver = true;
        }
    }

    public void HurtPlayer()
    {
        // Debug.Log("Ouch!Hazard particles");
        if (dieFX != null)
        {
            if (audioSFX != null)
            {
                audioSFX.PlayDieSFX();
            }

            dieFX.Play();
            Destroy(gameObject, 0.3f);
        }
    }



    void OnCollisionEnter(Collision other)
    {
        //Hazard
        if (other.collider.gameObject.CompareTag("Hazard") && !GameData.isGameOver)
        {
            GameData.isGameOver = true;

        }

        if (other.gameObject.CompareTag("Ground"))
        {
            playerController.BoostUpAndSpendEnergy(groundPushMod);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower") && !GameData.isGameOver)
        {
            RecoverPlayerEnergy();
            ScoreManager.IncreaseScore();
            uIController.UpdateScore();
        }

        if (other.gameObject.CompareTag("Hazard") && !GameData.isGameOver)
        {
            GameData.isGameOver = true;
        }

        if (other.gameObject.CompareTag("WinFlower") && !GameData.isGameOver && !isWinLevel)
        {

            isWinLevel = true;
            MeetWinLevelCondition();
            uIController.UpdateScore();

            //if (audioSFX != null)
            //{
            //    audioSFX.PlayWinLevelSFX();
            //}          
        }

    }

    public void MeetWinLevelCondition()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //=1 /2 /3
        int sceneCount = SceneManager.sceneCountInBuildSettings; //=4 

        if (winLevelFX != null)
        {
            if (currentSceneIndex < sceneCount - 1)
            {
                winLevelFX.Play();
                GameData.SetPlayerHPToMax();
                increaseHealthBar.Invoke();
                loadNextLevel.Invoke();
            }
            else
            {
                winLevelFX.Play();
                GameData.SetPlayerHPToMax();
                finishGame.Invoke();
            }
        }



    }

    public void RecoverPlayerEnergy()
    {
        if (nectarFX != null && !isEnergized)
        {
            if (audioSFX != null)
            {
                audioSFX.PlayNectarCollectionSFX();
            }
            isEnergized = true;
            nectarFX.Play();
            GameData.IncreasePlayerHP(10);
            increaseHealthBar.Invoke();
            StartCoroutine(EnergyCooldown());
        }
    }

    private IEnumerator EnergyCooldown()
    {
        yield return new WaitForSeconds(0.3f);
        isEnergized = false;
    }


    //void PlaySFX()
    //{
    //    if (audioSFX != null && !isPlayedSFX)
    //    {
    //        audioSFX.PlayGroundTouchSFX();
    //    }
    //    isPlayedSFX = true;
    //    StartCoroutine(PaySFXCooldown());
    //}

    //private IEnumerator PaySFXCooldown()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    isPlayedSFX = false;
    //}
}
