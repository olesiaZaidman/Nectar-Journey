using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConveyor : MonoBehaviour
{
    float speed = 0.025f; //0.003f; try 0.015 for i up test
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameData.isGameFreeze)
        { transform.Translate(new Vector3(0, 0, 1 * speed)); }

    }

    public void IncreaseConveyorSpeed() //float i like0.001
    {
        float i = 0.001f;
        speed += i;
    }
}
