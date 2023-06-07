using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem nectarFX;
    [SerializeField] ParticleSystem dieFX;

    public UnityEvent increaseHealthBar;
    bool isEnergized = false;
    UIController uIController;
    AudioEffects audioSFX;

    PlayerController playerController;
    private void Awake()
    {
        uIController = FindObjectOfType<UIController>();
        audioSFX = FindObjectOfType<AudioEffects>();
        playerController = GetComponent<PlayerController>();    
    }

    void OnParticleCollision(GameObject other)  //OnParticleTrigger
    {
        //Particle
        if (other.gameObject.CompareTag("Hazard"))
        {
            // Reduce player's health
            HurtPlayer();
        }

        
    }

    public void HurtPlayer()
    {
        Debug.Log("Ouch!Hazard particles");
        if (dieFX != null && !GameData.isGameOver)
        {
            GameData.isGameOver = true;
            if (audioSFX != null)
            {
                audioSFX.PlayDieSFX();
            }

            dieFX.Play();
            Destroy(gameObject, 0.5f);
        }
    }



    void OnCollisionEnter(Collision other)
    {
        //Hazard
        if (other.collider.gameObject.CompareTag("Hazard") && !GameData.isGameOver)
        {
            print("Triggered by a hazard!");
            HurtPlayer();
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            // Reduce player's health
            playerController.BoostUp(2);
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
    }
    public void RecoverPlayerEnergy()
    {
        Debug.Log("We have more energy!");
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
}
