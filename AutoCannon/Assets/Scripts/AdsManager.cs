using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public GameManager gameManager;
    public float timeAmount = 30f;
    Action onRewardedAdSuccess;

#if UNITY_ANDROID
    string gameId = "4813734";
#else
    string gameId = "4813735";
#endif
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAd(Action onSuccess)
    {
        onRewardedAdSuccess = onSuccess;
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");

        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error" + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            onRewardedAdSuccess.Invoke();
            /*gameManager.timer = timeAmount;
            gameManager.timeOverMenu.SetActive(false);*/
        }
    }
}
