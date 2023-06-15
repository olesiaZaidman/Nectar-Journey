using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    float velocity = 5f;
    Rigidbody rb;
    //  public float rotationSpeed = 100f;
    //  private bool isRotating = false;  // Track if rotation is in progress
    //  private Quaternion targetRotation;  // Target rotation of the GameObject

    public UnityEvent decreaseHealthBar;
    AudioEffects audioSFX;

    bool spentEnergy = false;

    int energySpent = 3;
    void Start()
    {
        audioSFX = FindObjectOfType<AudioEffects>();
        rb = GetComponent<Rigidbody>();
    }

    public void BoostUp(float _modifier)
    {

        rb.velocity = Vector3.up * velocity* _modifier;            // rb.AddForce(new Vector3(0, velocity, 0), ForceMode.Impulse);
    }



    // Update is called once per frame
    void Update()
    {
        //if (!GameData.isGameStarted)
        //{ return; }


        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) //0 is left click
        {
            BoostUp(1f);

            if (!spentEnergy)
            {
                spentEnergy = true;
                GameData.DecreasePlayerHP(energySpent);
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
