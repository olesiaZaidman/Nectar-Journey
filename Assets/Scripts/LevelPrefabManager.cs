
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelPrefabManager : MonoBehaviour
{
    public const int amountPrefabs = 10;
    public TextMeshProUGUI debug;

    public GameObject[] levelFlowerPrefabs;
    public GameObject[] levelHazardPrefabs;

    static GameObject[] levelPrefabs;

     static bool setIsReady = false;
    public static bool SetIsReady { get { return setIsReady;  } }

    public List<GameObject> combinedList = new List<GameObject>();

    private int counter = 0;

    void Awake()
    {
        GameData.SetLevelDifficulty();

        levelPrefabs = AddRandomObjectsToList(GameData.LevelDifficulty);
        //levelPrefabs = CreatePrefabsLevelSet(levelFlowerPrefabs, levelHazardPrefabs, difficulty);
        setIsReady = true;
        counter++;
    }

    public void CreateNewPrefabsSet()
    {
        // if (counter % 2 == 0)
        // {
        GameData.IncreaseLevelDifficulty();
        Debug.Log("Difficulty was increased" + GameData.LevelDifficulty);
        debug.SetText("Difficulty was increased: " + GameData.LevelDifficulty);
        //  }
        levelPrefabs = AddRandomObjectsToList(GameData.LevelDifficulty);
        counter++;
    }


    private GameObject[] AddRandomObjectsToList(float _difficulty)
    {
        combinedList.Clear();

        int badObjectAmount = (int)(amountPrefabs * _difficulty); //floor: 4.8 turns into 4
        int goodObjectsAmount = amountPrefabs - badObjectAmount;
        //Diff = 0,3 : Good amount:  7 Bad amount:  3

      //  Debug.Log("Good amount:  "+ goodObjectsAmount +" "+ "Bad amount:  "+ badObjectAmount);


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

}
