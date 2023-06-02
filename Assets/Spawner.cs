using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public BoxCollider colliderGround;
    float width;
    float length;
    void Awake()
    {
        width = colliderGround.bounds.size.x / 2;
        length = colliderGround.bounds.size.z / 2;

        Debug.Log("width: "+ width+ " "+ "length: "+ length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
