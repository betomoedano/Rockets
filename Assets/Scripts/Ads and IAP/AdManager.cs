using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string appStoreID = "3935320";
    private string playStoreID = "3935321";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string collectedCoinsX5 = "collectedCoinsX5";
    private string banner = "bannerShop";

    public bool isTargetPlayStore;
    public bool isTestAd;
    public bool isShowingBanner;


    public GameObject AdWatched,AdsX5Watched;
    public Text coinsX5Text;

    public static AdManager adsInstance;

    private void Awake()
    {
        adsInstance = this;
    }

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }

    public void showBanner()
    {
        StartCoroutine(ShowBannerWhenReady());  
    }

    public void HideBanner()
    {
        if(isShowingBanner == true)
        {
            Advertisement.Banner.Hide();
        }
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(banner))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(banner);
        isShowingBanner = true;
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

    public void PlayCoinsX5Ad ()
    {
        if (!Advertisement.IsReady(collectedCoinsX5))
        {
            return;
        }
        Advertisement.Show(collectedCoinsX5);
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
                if(placementId == collectedCoinsX5)
                {
                    RewardCoinsX5();
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
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        AdWatched.SetActive(true);
    }

    public void RewardCoinsX5()
    {
        int coinsToReward = UpdatterGameOver.gameoverInstance.collectedCoins * 5;
        GameState.gameState.coins += coinsToReward;
        GameState.gameState.SaveData();
        Debug.Log("Coins to Reward" + coinsToReward);
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        coinsX5Text.text = coinsToReward.ToString();
        AdsX5Watched.SetActive(true);
    }
}
