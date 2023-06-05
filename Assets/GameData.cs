using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    static int playerHP;
    const int playerMaxHP = 100;

    public static int PlayerHP { get { return playerHP; } }
    public static int PlayerMaxHP { get { return playerMaxHP; } }

    void Awake()
    {
        playerHP = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void IncreasePlayerHP(int _i)
    {
        playerHP += _i;
        playerHP = Mathf.Clamp(playerHP, 0, playerMaxHP);
    }

    public static void DecreasePlayerHP(int _i)
    {
        playerHP -= _i;
        playerHP = Mathf.Clamp(playerHP, 0, playerMaxHP);
    }
}
