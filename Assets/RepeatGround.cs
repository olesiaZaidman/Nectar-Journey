using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RepeatGround : MonoBehaviour
{
    public GameObject groundPrefab;

    private Vector3 startPosition = new Vector3(0, -4.3f, -15.2f);
    private Vector3 nextPosition = new Vector3(0, 0, 0);

    GameObject currentGround;
    GameObject nextGround;
    BoxCollider prefabCollider;

    public float zDistanceBetweenPrefabs; // = 40f
    private void Awake()
    {
        if (groundPrefab != null)
        {
            // Instantiate the prefab
             currentGround = SpawnGround(startPosition);

            // Get the BoxCollider component
            prefabCollider = currentGround.GetComponent<BoxCollider>();

            // Check if the BoxCollider component is attached
            if (prefabCollider != null)
            {
                // Access the collider bounds size
                zDistanceBetweenPrefabs = prefabCollider.bounds.size.z;  // = 40f
                nextPosition = startPosition - new Vector3(0, 0, zDistanceBetweenPrefabs);
                nextGround = SpawnGround(nextPosition);
            }
            else
            {
                Debug.LogError("BoxCollider component is not attached to the ground prefab.");
            }
        }

    }
    void Start()
    {
    }

    void Update()
    {
        if (GroundRespawnCheck(currentGround))
        {
            currentGround.transform.position = nextPosition;
        }
        if (GroundRespawnCheck(nextGround))
        {
            nextGround.transform.position = nextPosition;
        }
    }

    GameObject SpawnGround(Vector3 _position)
    {
        GameObject groundInstance = Instantiate(groundPrefab, _position, Quaternion.identity);
        return groundInstance;
    }

    bool GroundRespawnCheck(GameObject _curInstance)
    {
        if (_curInstance.transform.position.z > startPosition.z+ zDistanceBetweenPrefabs) //>25   -15+40 = 25
        {
            return true;
        }
        else return false;
    }
}
