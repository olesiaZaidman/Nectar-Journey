
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefabManager : MonoBehaviour
{
    public const int amountPrefabs = 10;

    [Range(0f, 1f)]
    public float difficulty = 0.5f;
    float difficultyMax = 0.7f;

    public GameObject[] levelFlowerPrefabs;
    public GameObject[] levelHazardPrefabs;
    static GameObject[] levelPrefabs;

     static bool setIsReady = false;
    public static bool SetIsReady { get { return setIsReady;  } }

    public List<GameObject> combinedList = new List<GameObject>();

    private int counter = 0;

    void Awake()
    { 
        levelPrefabs = AddRandomObjectsToList(difficulty);
        //levelPrefabs = CreatePrefabsLevelSet(levelFlowerPrefabs, levelHazardPrefabs, difficulty);
        setIsReady = true;
        counter++;
    }

    void IncreaseDifficulty() //float _increase
    {
        float diff = 0.1f;
        difficulty += diff;
        difficulty = Mathf.Clamp(difficulty, 0f, difficultyMax);
        Debug.Log("Difficulty was increased");
    }

    public void CreateNewPrefabsSet()
    {
        if (counter % 2 == 0)
        {
            IncreaseDifficulty();
        }
        levelPrefabs = AddRandomObjectsToList(difficulty);
        counter++;
    }


    private GameObject[] AddRandomObjectsToList(float _difficulty)
    {
        combinedList.Clear();

        int badObjectAmount = (int)(amountPrefabs * _difficulty); //floor: 4.8 turns into 4
        int goodObjectsAmount = amountPrefabs - badObjectAmount;

        //Diff = 0,3 : Good amount:  7 Bad amount:  3


       // float badObjectAmount = _difficulty;
     //   float goodObjectsAmount = 1 - badObjectAmount;
        Debug.Log("Good amount:  "+ goodObjectsAmount +" "+ "Bad amount:  "+ badObjectAmount);
        // Diff = 0,6 :  Good amount:  0.323 Bad amount:  0.677


        for (int i = 0; i < amountPrefabs; i++)
        {
            if (i < badObjectAmount)
            {
                int randomIndex = Random.Range(0, levelHazardPrefabs.Length);
                combinedList.Add(levelHazardPrefabs[randomIndex]);
            }
            else 
            {
                int randomIndex = Random.Range(0, levelFlowerPrefabs.Length);
                combinedList.Add(levelFlowerPrefabs[randomIndex]);
            }

       
           // float randomValue = Random.value; //random float between 0-1
           // Debug.Log("random Value:  " + randomValue);

            //if (randomValue < goodObjectsAmount)
            //{
            //    
            //    combinedList.Add(levelFlowerPrefabs[randomIndex]);

            //}
            //else
            //{
            //    int randomIndex = Random.Range(0, levelHazardPrefabs.Length);
            //    combinedList.Add(levelHazardPrefabs[randomIndex]);
            //}
        }
        ShuffleList(combinedList);
        return combinedList.ToArray();
    }


    void ShuffleList(List<GameObject> _list)
    {  /*Fisher-Yates algorithm. It iterates through the list in reverse order 
         * and swaps each element with a randomly selected element from the remaining portion of the list.*/
        for (int i = _list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = _list[i];
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }
    }

    public static GameObject[] GetPrefabs()
    {
        return levelPrefabs;
    }



    GameObject[] CreatePrefabsLevelSet(GameObject[] _goodPrefabs, GameObject[] _badPrefabs, float _proportionDifficulty)
    {
        List<GameObject> prefabsList = new List<GameObject>();
        float randomIndex = Random.Range(0.1f, _proportionDifficulty);

        return prefabsList.ToArray();
    }


    //GameObject[] CreatePrefabsLevelSet(GameObject[] _goodPrefabs, GameObject[] _badPrefabs, float _proportionDifficulty)
    //{
    //    //   index = Random.Range(0, levelPrefabs.Length);
    //    int badObjectAmount = (int)(amountPrefabs * _proportionDifficulty);
    //    int goodObjectsAmount = amountPrefabs - badObjectAmount;

    //    Debug.Log("badObjectAmount: " + badObjectAmount);
    //    Debug.Log("goodObjectsAmount: " + goodObjectsAmount);

    //    GameObject[] array1 = ChoosePrefabs(_badPrefabs, badObjectAmount);
    //    GameObject[] array2 = ChoosePrefabs(_goodPrefabs, goodObjectsAmount);

    //    GameObject[] levelSet = MergeArrays(array1, array2);

    //    return levelSet;
    //}

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
