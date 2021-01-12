using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string appStoreID = "3935320";
    private string playStoreID = "3935321";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }

    private void InitializeAdvertisement()
    {
        if(isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
        Advertisement.Initialize(appStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if(!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewarderVideoAd()
    {
        if(!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Advertisement.Show(rewardedVideoAd);
    }

    /// ////////////////////////////////////////////////////////////////////////////////////
  

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        switch (showResult)
        {
            case ShowResult.Failed:
                break;

            case ShowResult.Skipped:
                break;

            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {                   
                    RewardPlayer();
                }           
                if (placementId == interstitialAd) { Debug.Log("Intertitial Ad"); }               
                break;
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    public void RewardPlayer()
    {      
        int coinsToReward = 1000;
        GameState.gameState.coins += coinsToReward;
        GameState.gameState.SaveData();
        Debug.Log("Reward 1000 coins");
    }
}
