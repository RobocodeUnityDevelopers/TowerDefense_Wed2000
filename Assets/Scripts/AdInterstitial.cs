using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdInterstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdInterstitial S;
    [SerializeField] private string androidGameID = "Android_Interstitial";
    [SerializeField] private string iOSGameID = "iOS_Interstitial";

    private string gameID;

    private void Awake()
    {
        S = this;
        gameID = Application.platform == RuntimePlatform.Android ? androidGameID : iOSGameID;
    }

    public void LoadAd()
    {
        print("Ads loaded at" + gameID);
        Advertisement.Load(gameID, this);
    }

    public void ShowAd()
    {
        print("Showing ad at:" + gameID);
        Time.timeScale = 0f;
        Advertisement.Show(gameID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId) { }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print($"Ads failed with {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1f;
        LoadAd();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print($"Ads failed with {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId) { }
}
