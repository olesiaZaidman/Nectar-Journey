using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    float velocity = 6f;
    Rigidbody rb;
    //  public float rotationSpeed = 100f;
    //  private bool isRotating = false;  // Track if rotation is in progress
    //  private Quaternion targetRotation;  // Target rotation of the GameObject

    public UnityEvent decreaseHealthBar;

    bool spentEnergy = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!GameData.isGameStarted)
        //{ return; }


        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) //0 is left click
        {
            // rb.AddForce(new Vector3(0, velocity, 0), ForceMode.Impulse);
            rb.velocity = Vector3.up * velocity;

            if (!spentEnergy)
            {
                spentEnergy = true;
                GameData.DecreasePlayerHP(2);
                decreaseHealthBar.Invoke();
                StartCoroutine(FlyCooldown());
            }


            Vector3 mousePos = Input.mousePosition;
            float screenWidth = Screen.width;

            if (mousePos.x < screenWidth / 2)//&& !isRotating
            {
                //targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.up * 180f);
              //  isRotating = true;
              //  StartCoroutine(RotateObjectRoutine());
                // Rotate to the left
                // rb.AddTorque(Vector3.up * rotationSpeed);
            }
            else
            {
              //  isRotating = false;
              //  targetRotation = Quaternion.Euler(transform.rotation.eulerAngles - Vector3.up * 180f);
               // StartCoroutine(RotateObjectRoutine());
                // Rotate to the right
                // rb.AddTorque(-Vector3.up * rotationSpeed);
            }


        }

    }

    private IEnumerator FlyCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        spentEnergy = false;
    }



    //private IEnumerator RotateObjectRoutine()
    //{
    //    isRotating = true;

    //    while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
    //    {
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    //        yield return null;
    //    }

    //    isRotating = false;
    //}

    public void TurnPlayerInDirection(int _direction)
    {
        //rb.AddTorque(Vector3.right * _direction);
        //(Vector3.right * _direction, Space.Self);     
    }

    
}
