using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoinsStartMenu : MonoBehaviour
{
    public Text totalCoins;

    void Start()
    {
        totalCoins = GetComponent<Text>();
    }

   
    void Update()
    {
        totalCoins.text = GameState.gameState.coins.ToString();
    }
}
