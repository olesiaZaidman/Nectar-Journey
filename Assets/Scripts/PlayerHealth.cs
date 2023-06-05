using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public ParticleSystem nectarFX;
    public ParticleSystem dieFX;
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
            SceneLoadManager.isGameOver = true;
        }
    }

    public void RecoverPlayerEnergy()
    {
        Debug.Log("We have more energy!");
        if (nectarFX != null) 
        { 
            nectarFX.Play();
        }
       
    }

    void OnCollisionEnter(Collision other)
    {
        //Hazard
        if (other.collider.gameObject.CompareTag("Hazard") && !SceneLoadManager.isGameOver)
        {
            print("Triggered by a hazard!");
            HurtPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {    
        if (other.gameObject.CompareTag("Flower") && !SceneLoadManager.isGameOver)
        {
            RecoverPlayerEnergy();
        }
    }

}
