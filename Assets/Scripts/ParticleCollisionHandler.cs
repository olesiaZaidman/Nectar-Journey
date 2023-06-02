using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionHandler : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        // Check if the collision is with the particles
        if (other.CompareTag("Player"))
        {
          //  Debug.Log("Particle collision with player detected!");
            // Add your custom logic here to handle the collision with particles
        }
    }

    private void OnParticleTrigger()
    {
        Debug.Log("Particle triggers by player detected!");

    }
}
