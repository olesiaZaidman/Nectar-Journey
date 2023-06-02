using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    BoxCollider colliderGround;
   public GameObject[] levelPrefabs;
    public Transform parentTransform;
    int index;
  //  float width;
    float length;
    float xPos =0f;
    float yPos = -3.6f;
    float zPos;
    int amountPrefabs = 10;


     float prefabSpacing; // Spacing between each prefab
     float startPositionZ = 17f; // Starting position on the Z-axis


    void Awake()
    {
        parentTransform = GetComponent<Transform>();    
        colliderGround = GetComponent<BoxCollider>();

     //   width = colliderGround.bounds.size.x / 2;
        length = colliderGround.bounds.size.z / 2;
      //  xPos = width;
        prefabSpacing = (length*2) / amountPrefabs; //= 4f;
        zPos = startPositionZ;

      //  Debug.Log("width: "+ width+ " "+ "length: "+ length);
      //  Debug.Log("Array length: " + levelPrefabs.Length); //8
    }

    private void Start()
    {
        SpawnLevelPrefabs();
    }


    void SpawnLevelPrefabs()
    {
        //instantiate 10 prefabs at intervals of 4 units on the Z-axis:
        for (int i = 0; i < amountPrefabs; i++)
        {
            // Calculate the index of the prefab to instantiate
            index = Random.Range(0, levelPrefabs.Length); //exclusive OR            // int index = i % levelPrefabs.Length;

            // Instantiate the prefab at the current position
             GameObject instance =  Instantiate(levelPrefabs[index], new Vector3(xPos, levelPrefabs[index].transform.position.y+yPos, zPos+transform.position.z), Quaternion.identity);
            //+parentTransform.

            instance.name = levelPrefabs[index].name+"_" +(i+1);   
             instance.transform.SetParent(parentTransform);

            // Increment the Z-coordinate for the next instantiation
            zPos -= prefabSpacing;
        }
    }
}
