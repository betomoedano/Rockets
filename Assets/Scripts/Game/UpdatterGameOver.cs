using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class UpdatterGameOver : MonoBehaviour
{
    string reach500Meters = "reach500Meters";
    string reach1000Meters = "reach1000Meters";
    string reach1500Meters = "reach1500Meters";
    string reach2000Meters = "reach2000Meters";

    public Text actual;
    public Text youFlew;
    public Text bestFly;

    public Points points;
    public int collectedCoins;
    public static UpdatterGameOver gameoverInstance;

    public GameObject score;
    public GameObject distance;

    private void Start()
    {
        gameoverInstance = this;
    }
    private void OnEnable()
    {
        score.SetActive(false);
        distance.SetActive(false);
        if (points.distanceInt > GameState.gameState.bestFly)
        {
            GameState.gameState.bestFly = points.distanceInt;
            GameState.gameState.SaveData();
            GameCenter.gameCenterInstance.AddScoreToLeaderboard(GameState.gameState.bestFly);
            //PlayServices.googleServices.AddScoreToLeaderboard((int)GameState.gameState.bestFly);
            //if (PlayServices.googleServices.isConnectedToGooglePlayServices)
            //{
            //    Social.ReportScore((int)GameState.gameState.bestFly, "CgkIm_nJqtsKEAIQAg", (success) =>
            //    {
            //        if (success) Debug.Log("Score posted!!");
            //        if (!success) Debug.LogError("Unable to Post Score");

            //    });

            //}
            //GPGDemo.AddScoreToLeaderBoard("Ranking",GameState.gameState.bestFly);
            //CloudOnceServices.instance.SubmitScoreToLeaderboard(GameState.gameState.bestFly);
        }
        youFlew.text = points.distanceInt.ToString();
        bestFly.text = GameState.gameState.bestFly.ToString();
        collectedCoins = points.points;
        actual.text = points.points.ToString();
        RefreshTotalScore();

        if(GameState.gameState.bestFly >= 500 && GameCenter.gameCenterInstance.isConnectedToGameCenter)
        {
            GameCenter.gameCenterInstance.ReportAchievement(reach500Meters);
        }
        if (GameState.gameState.bestFly >= 1000 && GameCenter.gameCenterInstance.isConnectedToGameCenter)
        {
            GameCenter.gameCenterInstance.ReportAchievement(reach1000Meters);
        }
        if (GameState.gameState.bestFly >= 1500 && GameCenter.gameCenterInstance.isConnectedToGameCenter)
        {                                      
            GameCenter.gameCenterInstance.ReportAchievement(reach1500Meters);
        }                                      
        if (GameState.gameState.bestFly >= 2000 && GameCenter.gameCenterInstance.isConnectedToGameCenter)
        {
            GameCenter.gameCenterInstance.ReportAchievement(reach2000Meters);
        }
    }

    public void RefreshTotalScore()
    {
        GameState.gameState.coins += points.points;
        GameState.gameState.SaveData();
        points.points = 0;
    }
}
