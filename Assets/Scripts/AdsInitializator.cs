using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializator : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameID = "5471364";
    [SerializeField] private string iOSGameID = "5471365";
    [SerializeField] private bool testMode = false;

    private string gameID;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        gameID = Application.platform == RuntimePlatform.Android ? androidGameID : iOSGameID;
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        print("Ads initialize completed");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print($"Ads failed with {error.ToString()} - {message}");
    }

}
