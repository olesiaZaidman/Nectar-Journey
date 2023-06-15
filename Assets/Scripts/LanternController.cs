using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    float velocity = 2;
    public float destroyThreshold = 10f;
    public float raycastDistance = 20f;

    void FixedUpdate()
    {
        HazardCollisionCheck();
        MoveLantern();
        DestroyAfterThresholdCheck();
    }

    void HazardCollisionCheck()
    {
        // herer we are adjusting the position of the raycast origin to avoid hitting the GameObject itself: 
        Vector3 delta = new Vector3(0,4,0);
        Vector3 position = transform.position - delta;

        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit, raycastDistance))
        {
            Debug.DrawRay(position, Vector3.down * raycastDistance, Color.red);

            // if (hit.collider.CompareTag("Hazard"))
            if (hit.transform.CompareTag("Hazard"))
            {
                Debug.Log("Hazard is there");
                Debug.Log("hit " + hit.transform.name);
                Debug.DrawRay(position, Vector3.down * raycastDistance, Color.green);
                Destroy(gameObject);
            }

            else if (hit.transform.CompareTag("Flower"))
            {
                Debug.Log("hit " + hit.transform.name);
                Debug.DrawRay(position, Vector3.down * raycastDistance, Color.yellow);

            }
        }
    }

    void MoveLantern()
    {
        transform.Translate(new Vector3(0, 0, 1) * velocity * Time.deltaTime, Space.World);
    }

    void DestroyAfterThresholdCheck()
    {
        if (transform.position.z > destroyThreshold)
        {
            Destroy(gameObject);

        }
    }
}
