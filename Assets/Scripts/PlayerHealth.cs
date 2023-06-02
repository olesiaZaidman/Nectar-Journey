using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            print("Triggered by a hazard!");
        }
    }


    void OnCollisionEnter(Collision other)
    {
        //Hazard
        if (other.collider.gameObject.CompareTag("Hazard"))
        {
            print("Collided with a hazard!");
        }
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
    }
}
