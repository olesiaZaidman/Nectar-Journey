
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSpawner : MonoBehaviour
{
    float xCoordinate = 0;
    float yCoordinate = 7f;
    float zCoordinate = -21f;
    Vector3 pos;

    public GameObject[] prefabs;
    int index;


    float startTime = 4f;

    float minRepeatTime = 1f;
    float maxRepeatTime = 5f; //3-20

    void Start()
    {
        pos = new Vector3(xCoordinate, yCoordinate, zCoordinate);
        Invoke("Spawn", startTime);
    }

    void Spawn() //GameObject Spawn() 
    {
        index = Random.Range(0, prefabs.Length);
        float repeatTime = Random.Range(minRepeatTime, maxRepeatTime);
        Quaternion prefabRotation = prefabs[index].transform.rotation;

        GameObject instance = Instantiate(prefabs[index], pos, prefabRotation);
      //  return instance;

        Invoke("Spawn", repeatTime);
    }
}
