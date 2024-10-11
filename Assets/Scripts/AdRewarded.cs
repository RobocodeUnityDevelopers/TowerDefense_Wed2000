using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class AdRewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidGameID = "Rewarded_Android";
    [SerializeField] private string iOSGameID = "Rewarded_iOS";
    [SerializeField] private Button rewardedBut;
    private string gameID;

    private void Awake()
    {
        gameID = Application.platform == RuntimePlatform.Android ? androidGameID : iOSGameID;
        rewardedBut.interactable = false;
        StartCoroutine(InitLoad(1f));
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

    private IEnumerator InitLoad(float time)
    {
        yield return new WaitForSeconds(time);
        LoadAd();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (gameID.Equals(placementId))
        {
            rewardedBut.onClick.AddListener(ShowAd);
            rewardedBut.interactable = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print($"Ads failed with {error.ToString()} - {message}");
    }
   
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(gameID.Equals(placementId) && showCompletionState == UnityAdsShowCompletionState.COMPLETED) 
        {
            if (rewardedBut.interactable)
            {
                print("Rewarded");
                CoinController.AddCoin(15);
                rewardedBut.interactable = false;
                StartCoroutine(InitLoad(5f));
                Time.timeScale = 1f;
            }
        }
    }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print($"Ads failed with {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId) { }
    public void OnUnityAdsShowStart(string placementId) { }

    private void OnDestroy()
    {
        rewardedBut.onClick.RemoveAllListeners();
    }

}
