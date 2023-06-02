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
    float yPos = -3.5f;
    float zPos;
    int amountPrefabs = 10;


     float prefabSpacing; // Spacing between each prefab
    // float startPositionZ = 17f; // Starting position on the Z-axis


    void Awake()
    {
        parentTransform = GetComponent<Transform>();    
        colliderGround = GetComponent<BoxCollider>();

     //   width = colliderGround.bounds.size.x / 2;
        length = colliderGround.bounds.size.z / 2;
      //  xPos = width;
        prefabSpacing = (length*2) / amountPrefabs; //= 4f;
      //  zPos = startPositionZ;

      //  Debug.Log("width: "+ width+ " "+ "length: "+ length);
      //  Debug.Log("Array length: " + levelPrefabs.Length); //8
    }

    private void Start()
    {
        SpawnLevelPrefabs(transform.position.z); 
    }


    void SpawnLevelPrefabs(float _offset)
    {
        float startPositionZ = 17f;
        zPos = startPositionZ;
        //instantiate 10 prefabs at intervals of 4 units on the Z-axis:
        for (int i = 0; i < amountPrefabs; i++)
        {
            // Calculate the index of the prefab to instantiate
            index = Random.Range(0, levelPrefabs.Length); //exclusive OR            // int index = i % levelPrefabs.Length;

            // Instantiate the prefab at the current position
             GameObject instance =  Instantiate(levelPrefabs[index], new Vector3(xPos,yPos+ levelPrefabs[index].transform.position.y, zPos+_offset), Quaternion.identity);
            //+parentTransform.

            instance.name = levelPrefabs[index].name+"_" +(i+1);   
             instance.transform.SetParent(parentTransform);

            // Increment the Z-coordinate for the next instantiation
            zPos -= prefabSpacing;
        }
    }

    public void ReSpawnLevelPrefabs(float _offset)
    {
        float startPositionZ = 17f;
        zPos = startPositionZ;
        //instantiate 10 prefabs at intervals of 4 units on the Z-axis:
        for (int i = 0; i < amountPrefabs; i++)
        {
            // Calculate the index of the prefab to instantiate
            index = Random.Range(0, levelPrefabs.Length); //exclusive OR            // int index = i % levelPrefabs.Length;

            // Instantiate the prefab at the current position
            GameObject instance = Instantiate(levelPrefabs[index], new Vector3(xPos, yPos + levelPrefabs[index].transform.position.y, zPos + _offset), Quaternion.identity);
            //+parentTransform.

            instance.name = levelPrefabs[index].name + "_" + (i + 1);
            instance.transform.SetParent(parentTransform);

            // Increment the Z-coordinate for the next instantiation
            zPos -= prefabSpacing;
        }
    }

    public void DeleteAllChildren()
    {
        // Loop through all the children of the parent
        for (int i = parentTransform.childCount - 1; i >= 0; i--)
        {
            // Get the child at the current index
            Transform child = parentTransform.GetChild(i);

            // Destroy the child GameObject
            Destroy(child.gameObject);
        }
    }


}
