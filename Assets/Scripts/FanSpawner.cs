using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpawner : ObjectsInAirSpawner
{
    [SerializeField] float yMinCoordinate = 1.74f;
    [SerializeField] float yMaxCoordinate = 5f;
    public override void Spawn()
    {
        yCoordinate = Random.Range(yMinCoordinate, yMaxCoordinate);
        pos = new Vector3(xCoordinate, yCoordinate, zCoordinate);
        index = Random.Range(0, prefabs.Length);
        float repeatTime = Random.Range(minSpawnRepeatTime, maxSpawnRepeatTime);
        Quaternion prefabRotation = prefabs[index].transform.rotation;

        GameObject instance = Instantiate(prefabs[index], pos, prefabRotation);

        Invoke("Spawn", repeatTime);
    }
}
