
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInAirSpawner : MonoBehaviour
{
    [SerializeField] protected float xCoordinate = 0;
    [SerializeField] protected float yCoordinate = 7f;
    [SerializeField] protected float zCoordinate = -21f;

    [SerializeField] protected float startTimeDelay = 4f;
    [SerializeField] protected float minSpawnRepeatTime = 2f;
    [SerializeField] protected float maxSpawnRepeatTime = 10f; //3-20

    protected Vector3 pos;

    public GameObject[] prefabs;
    protected int index;


    void OnEnable()
    {
        StartSpawningWithIntervals();
    }

    void OnDisable()
    {
        CancelSpawning();
    }


    public virtual void StartSpawningWithIntervals()
    {
        pos = new Vector3(xCoordinate, yCoordinate, zCoordinate);
        Invoke("Spawn", startTimeDelay);
    }

    public virtual void CancelSpawning()
    {
        CancelInvoke("Spawn");
    }
    public virtual void Spawn()
    {
        index = Random.Range(0, prefabs.Length);
        float repeatTime = Random.Range(minSpawnRepeatTime, maxSpawnRepeatTime);
        Quaternion prefabRotation = prefabs[index].transform.rotation;

        GameObject instance = Instantiate(prefabs[index], pos, prefabRotation);

        Invoke("Spawn", repeatTime);
    }
}
