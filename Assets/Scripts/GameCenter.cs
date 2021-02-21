using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
using System;

public class GameCenter : MonoBehaviour
{
    public static GameCenter gameCenterInstance;
    public bool isConnectedToGameCenter;
    private string leaderboardID = "CgkIm_nJqtsKEAIQAg";

    private void Awake()
    {
        gameCenterInstance = this;
    }

    void Start()
    {
        SignInToGameCenter();
    }

    public void SignInToGameCenter()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                isConnectedToGameCenter = true;
                Debug.Log("User connected to gamecenter");
            }
            else
            {
                Debug.Log("User NOT connected to gamecenter");
            }
        });
    }

    public void AddScoreToLeaderboard(int bestFly)
    {
        if(isConnectedToGameCenter)
        {
            Social.ReportScore(bestFly, leaderboardID, (success) =>
                {
                    if (!success) Debug.Log("Unable to post Score");
                });
        }
        else
        {
            Debug.Log("Not signed in unable to post score");
        }
    }

    public void ShowLeaderboard()
    {
        if(isConnectedToGameCenter)
        {
            Social.ShowLeaderboardUI();
            Debug.Log("Show LeaderboardUI Pressed");
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    isConnectedToGameCenter = true;
                    Debug.Log("User connected to gamecenter");
                }
                else
                {
                    Debug.Log("User NOT connected to gamecenter");
                }
            });
        }
    }

    public void ReportAchievement(string achievementId)
    {
        if(isConnectedToGameCenter)
        {
            Social.ReportProgress(achievementId, 100, (result) =>
            {
                Debug.Log(result ? "Reported achievement" : "Failed to report achievement");
            });
        }
    }

} 
