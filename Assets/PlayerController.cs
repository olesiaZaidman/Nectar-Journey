using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float velocity = 4f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) //0 is left click
        {
            // rb.AddForce(new Vector3(0, velocity, 0), ForceMode.Impulse);
            rb.velocity = Vector3.up * velocity;
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
}
