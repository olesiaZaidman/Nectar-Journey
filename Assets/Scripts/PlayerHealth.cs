using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem nectarFX;
    [SerializeField] ParticleSystem dieFX;
    [SerializeField] ParticleSystem winLevelFX;


    public UnityEvent increaseHealthBar;
    public UnityEvent loadNextLevel;

    bool isEnergized = false;
    float groundPushMod = 1.5f;

    bool isDead = false;
    UIController uIController;
    AudioEffects audioSFX;
    bool isPlayedSFX = false;
    PlayerController playerController;
     void Awake()
    {
        uIController = FindObjectOfType<UIController>();
        audioSFX = FindObjectOfType<AudioEffects>();
        playerController = GetComponent<PlayerController>();    
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
            // Reduce player's health
         //  !!! GameData.isGameOver = true;
           // HurtPlayer();
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
        //    print("Triggered by a hazard!");
         GameData.isGameOver = true;
          //  HurtPlayer();
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            // Reduce player's health?
           
            playerController.BoostUp(groundPushMod);
        }
    }

    void OnTriggerEnter(Collider other)
    {    
        if (other.gameObject.CompareTag("Flower") && !GameData.isGameOver)
        {
           
            RecoverPlayerEnergy();
            GameData.IncreaseScore();
            uIController.UpdateScore();
        }

        if (other.gameObject.CompareTag("WinFlower") && !GameData.isGameOver)
        {
            //  RecoverPlayerEnergy();
            //  GameData.IncreaseScore();
            //save score
            MeetWinLevelCondition();
            uIController.UpdateScore();
        }

        //if (other.gameObject.CompareTag("Grass") && !GameData.isGameOver)
        //{
        //    PlaySFX();
        //}
    }

    public void MeetWinLevelCondition()
    {
        if (winLevelFX != null)
        {
            winLevelFX.Play();
            GameData.SetPlayerHPToMax();
            increaseHealthBar.Invoke();
            loadNextLevel.Invoke();
        }

    }

    public void RecoverPlayerEnergy()
    {
     //   Debug.Log("We have more energy!");
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


    void PlaySFX()
    {
        if (audioSFX != null && !isPlayedSFX)
        {
            audioSFX.PlayGroundTouchSFX();
        }
        isPlayedSFX = true;
        StartCoroutine(PaySFXCooldown());
    }

    private IEnumerator PaySFXCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isPlayedSFX = false;
    }
}
