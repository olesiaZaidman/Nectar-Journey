
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelPrefabManager : MonoBehaviour
{
    public const int amountPrefabs = 10;

    [Range(0f, 1f)]
    public float difficulty = 0.5f;
    public GameObject[] levelFlowerPrefabs;
    public GameObject[] levelHazardPrefabs;
    static GameObject[] levelPrefabs;

     static bool setIsReady = false;
    public static bool SetIsReady { get { return setIsReady;  } }
    void Awake()
    {
        levelPrefabs = CreatePrefabsLevelSet(levelFlowerPrefabs, levelHazardPrefabs, difficulty);
        setIsReady = true;
        //OR CreateNewPrefabsSet();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static GameObject[] GetPrefabs()
    {
        return levelPrefabs;
    }

    public void CreateNewPrefabsSet()
    {
        levelPrefabs = CreatePrefabsLevelSet(levelFlowerPrefabs, levelHazardPrefabs, difficulty);
    }



    GameObject[] CreatePrefabsLevelSet(GameObject[] _goodPrefabs, GameObject[] _badPrefabs, float _proportionDifficulty)
    {
        //   index = Random.Range(0, levelPrefabs.Length);
        int badArraySize = (int)(amountPrefabs * _proportionDifficulty);
        int goodArraySize = amountPrefabs - badArraySize;

        Debug.Log("badArraySize: " + badArraySize);
        Debug.Log("goodArraySize: " + goodArraySize);

        GameObject[] array1 = ChoosePrefabs(_badPrefabs, badArraySize);
        GameObject[] array2 = ChoosePrefabs(_goodPrefabs, goodArraySize);

        GameObject[] levelSet = MergeArrays(array1, array2);

        return levelSet;
    }

    GameObject[] ChoosePrefabs(GameObject[] _prefabCollection, int _amount)
    {       
        GameObject[] collection = new GameObject[_amount];

        for (int i = 0; i < collection.Length; i++)
        {
            int index = Random.Range(0, _prefabCollection.Length);
            collection[i] = _prefabCollection[index];
        }

        return collection;
    }

    GameObject[] MergeArrays(GameObject[] _array1, GameObject[] _array2)
    {
        // int length = _array1.Length + _array2.Length;

        // GameObject[] mergedArray = new GameObject[length];
        GameObject[] mergedArray = new GameObject[amountPrefabs];

        int index1 = 0;
        int index2 = 0;

        // for (int i = 0; i < length; i++)
        for (int i = 0; i < amountPrefabs; i++)
        {
            // Mix between _array1 and _array2
            if (i % 2 == 0 && index1 < _array1.Length)
            {
                mergedArray[i] = _array1[index1];
                index1++;
            }
            else if (index2 < _array2.Length)
            {
                mergedArray[i] = _array2[index2];
                index2++;
            }
        }
        return mergedArray;
    }


}
