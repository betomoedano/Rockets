using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayServices : MonoBehaviour
{
    public static PlayServices googleServices;
    public bool isConnectedToGooglePlayServices;
      
    private void Awake()
    {
        googleServices = this;
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    void Start()
    {
        SignInToGooglePlayServices();
        //try
        //{
        //    PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //    PlayGamesPlatform.InitializeInstance(config);
        //    Social.localUser.Authenticate((bool success) => {Debug.Log("SUCCESS signed"); });
        //}
        //catch(Exception exception)
        //{
        //    Debug.Log(exception);
        //    Debug.Log("Not signed");
        //}
    }

    public void SignInToGooglePlayServices()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
        {
            switch (result)
            {
                case SignInStatus.Success:
                    isConnectedToGooglePlayServices = true;
                    Debug.Log("User coneccted to google play services");
                    break;
                default:
                    isConnectedToGooglePlayServices = false;
                    Debug.Log("User NOT coneccted to google play services");
                    break;
            }
        });
    }

    public void AddScoreToLeaderboard(int bestFly)
    {
        if(isConnectedToGooglePlayServices)
        {
            Social.ReportScore(bestFly, "CgkIm_nJqtsKEAIQAg", (success) =>
            {
                if(!success) Debug.LogError("Unable to Post Score");
                
            });
        }
        else
        {
            Debug.Log("Not Signed In... Unable to report score");
        }
    }

    public void ShowLeaderboard()
    {
        if (isConnectedToGooglePlayServices)
        {
            Social.ShowLeaderboardUI();
            //PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIm_nJqtsKEAIQAA");
            Debug.Log("Show leadearboard PRESSED");
        }
        else
        {
            Debug.Log("User not authenticated");
        }
    }
}
