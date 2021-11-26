using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    private string gameId = "4474497";
    private void Start() {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
        ShowBanner();
    }

    public void PlayAd(){
        if(Advertisement.IsReady("Interstitial_Android")){
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void PlayRewardedAd(){
        if(Advertisement.IsReady("Rewarded_Android")){
            Advertisement.Show("Rewarded_Android");
        }
        else{
            Debug.Log("No Ad");
        }
    }

    public void HideBanner(){
        Advertisement.Banner.Hide();
    }

    public void ShowBanner(){
        if(Advertisement.IsReady("Banner_Android")){
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }
    }

    public void OnUnityAdsReady(string placementId){
        Debug.Log("Ads Ready");
    }
    public void OnUnityAdsDidError(string message){
        Debug.Log("Error");
    }
    public void OnUnityAdsDidStart(string placementId){
        Debug.Log("Started Ad");
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult){
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished){
            Debug.Log("Reward");
        }
    }
}
