using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatterGameOver : MonoBehaviour
{
    public Text actual;
    public Text youFlew;
    public Text bestFly;
    public Points points;

    public GameObject score;
    public GameObject distance;

    private void OnEnable()
    {
        score.SetActive(false);
        distance.SetActive(false);
        if (points.distanceInt > GameState.gameState.bestFly)
        {
            GameState.gameState.bestFly = points.distanceInt;
            GameState.gameState.SaveData();
        }
        youFlew.text = points.distanceInt.ToString();
        bestFly.text = GameState.gameState.bestFly.ToString(); 
        actual.text = points.points.ToString();
        RefreshTotalScore();
    }

    public void RefreshTotalScore()
    {
        GameState.gameState.coins += points.points;
        GameState.gameState.SaveData();
        points.points = 0;
    }
}
