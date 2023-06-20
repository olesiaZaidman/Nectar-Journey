using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotator : MonoBehaviour
{
    float speed = 4f;
    public float destroyThreshold = 10f;
    float velocity = 3;
 
    void FixedUpdate()
    {
        Move();
        DestroyAfterThresholdCheck();
        transform.Rotate(new Vector3(0, 0, -1* speed));
    }

    void DestroyAfterThresholdCheck()
    {
        if (transform.position.z > destroyThreshold)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.Translate(new Vector3(0, 0, 1) * velocity * Time.deltaTime, Space.World);
    }

}
