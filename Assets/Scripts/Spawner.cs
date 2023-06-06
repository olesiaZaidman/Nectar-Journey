using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    BoxCollider colliderGround;

    Transform parentTransform;
    int index;
    float length;
    float xPos =0f;
    float yPos = -3.5f;
    float zPos;
     float prefabSpacing; // Spacing between each prefab
     float startPositionZ = 17f; // Starting position on the Z-axis

    // int amountPrefabs;

    // GameObject[] levelPrefabs;
   // LevelPrefabManager levelPrefabManager;

    void Awake()
    { 
        parentTransform = GetComponent<Transform>();    
        colliderGround = GetComponent<BoxCollider>();
        length = colliderGround.bounds.size.z / 2;

        prefabSpacing = (length*2) / LevelPrefabManager.amountPrefabs; //= 4f;

      //  Debug.Log("Array length: " + levelPrefabs.Length); //8
    }

    private void Start()
    {
        if (LevelPrefabManager.SetIsReady)
        { 
            SpawnLevelPrefabs(LevelPrefabManager.GetPrefabs(), transform.position.z);
        }

    }

    void SpawnLevelPrefabs(GameObject[] _levelPrefabs, float _offset)
    {
        zPos = startPositionZ;
        //instantiate 10 prefabs at intervals of 4 units on the Z-axis:
        for (int i = 0; i < LevelPrefabManager.amountPrefabs; i++)
        {
            // Calculate the index of the prefab to instantiate
            index = Random.Range(0, _levelPrefabs.Length); //exclusive OR            // int index = i % levelPrefabs.Length;

            // Instantiate the prefab at the current position
             GameObject instance =  Instantiate(_levelPrefabs[index], new Vector3(xPos,yPos+ _levelPrefabs[index].transform.position.y, zPos+_offset), Quaternion.identity);
            //+parentTransform.

            instance.name = _levelPrefabs[index].name+"_" +(i+1);   
            instance.transform.SetParent(parentTransform);

            // Increment the Z-coordinate for the next instantiation
            zPos -= prefabSpacing;
        }
    }

    public void ReSpawnLevelPrefabs(GameObject _ground) 
    {

        SpawnLevelPrefabs(LevelPrefabManager.GetPrefabs(), _ground.transform.position.z);
        //float _offset = _ground.transform.position.z)

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
