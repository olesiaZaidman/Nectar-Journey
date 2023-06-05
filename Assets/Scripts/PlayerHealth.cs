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

    private void Awake()
    {
        uIController = FindObjectOfType<UIController>();    
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
        if (dieFX != null)
        {
            dieFX.Play();
            Destroy(gameObject, 0.5f);
            GameData.isGameOver = true;
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
