using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

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
