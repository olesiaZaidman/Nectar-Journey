using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotator : MonoBehaviour
{
  //  float speed = 0.0001f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1));
        //transform.Translate(new Vector3(1, 0, 0 * speed));
    }
}
