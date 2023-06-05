using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConveyor : MonoBehaviour
{
     float speed = 0.003f; //0.003f; try 0.015 for speed up test
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,1* speed));
    }
}
