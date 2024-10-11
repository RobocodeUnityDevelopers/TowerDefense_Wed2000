using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdBanner : MonoBehaviour
{
    [SerializeField] private string androidGameID = "Banner_Android";
    [SerializeField] private string iOSGameID = "Banner_iOS";
    [SerializeField] private BannerPosition bannerPos;

    private string gameID;

    private void Awake()
    {
        gameID = Application.platform == RuntimePlatform.Android ? androidGameID : iOSGameID;
    }
    private void Start()
    {
        Advertisement.Banner.SetPosition(bannerPos);
        StartCoroutine(ShowAfterDelay());
    }

    private  IEnumerator ShowAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        LoadBanner();
    }

    private void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions{
            loadCallback = OnBannerLoad,
            errorCallback = OnBannerError
        };
        Advertisement.Banner.Load(gameID, options);
    }
    public void ShowBanner()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShow
        };
        Advertisement.Banner.Show(gameID, options);
    }
    public void HideBanner() 
    {
        Advertisement.Banner.Hide();
    }
    
    private void OnBannerError(string message) 
    {
        print($"Banner failed with: {message}");
    }
    private void OnBannerLoad() { }
    private void OnBannerClicked() { }
    private void OnBannerShow() { }
    private void OnBannerHidden() { }
}
