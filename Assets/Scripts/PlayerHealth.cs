using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

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
    }

    public void RecoverPlayerEnergy()
    {
        Debug.Log("We have more energy!");
    }

    void OnCollisionEnter(Collision other)
    {
        //Hazard
        if (other.collider.gameObject.CompareTag("Hazard"))
        {
            print("Triggered by a hazard!");
        }
    }

    void OnTriggerEnter(Collider other)
    {    
        if (other.gameObject.CompareTag("Flower"))
        {
            RecoverPlayerEnergy();
        }
    }



}
