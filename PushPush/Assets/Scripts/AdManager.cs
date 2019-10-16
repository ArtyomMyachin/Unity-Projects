using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System;

public class AdManager : MonoBehaviour, ISkippableVideoAdListener, IInterstitialAdListener, INonSkippableVideoAdListener, IRewardedVideoAdListener
{
#if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
  string appKey = "";
#elif UNITY_ANDROID
    string appKey = "b7150ecf6870faa51524612ca9f8b4b6fbfd4573230afb95";
    bool throughHint = false;
    /*#elif UNITY_IPHONE
     string appKey = "722fb56678445f72fe2ec58b2fa436688b920835405d3ca6";*/
#else
  string appKey = "";
#endif

    public static AdManager instance;
    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
#if UNITY_ANDROID
    void Start()
    {
        Appodeal.disableWriteExternalStoragePermissionCheck();
        Appodeal.confirm(Appodeal.SKIPPABLE_VIDEO);
        Appodeal.setSkippableVideoCallbacks(this);
        Appodeal.setInterstitialCallbacks(this);
        Appodeal.setNonSkippableVideoCallbacks(this);
        Appodeal.setRewardedVideoCallbacks(this);
        Appodeal.initialize(appKey, Appodeal.SKIPPABLE_VIDEO | Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.REWARDED_VIDEO);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowAd()
    {
        if (!Appodeal.isLoaded(Appodeal.SKIPPABLE_VIDEO | Appodeal.INTERSTITIAL))
            return;
        throughHint = false;
        Appodeal.show(Appodeal.SKIPPABLE_VIDEO | Appodeal.INTERSTITIAL);        
    }
    public void ShowHintVideo()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
        else
        {
            throughHint = true;
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
    }
    public void onSkippableVideoClosed()
    {
        throw new NotImplementedException();
    }

    public void onSkippableVideoFailedToLoad()
    {
        throw new NotImplementedException();
    }

    public void onSkippableVideoFinished()
    {
        throw new NotImplementedException();
    }

    public void onSkippableVideoLoaded()
    {
        throw new NotImplementedException();
    }

    public void onSkippableVideoShown()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialLoaded()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialFailedToLoad()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialShown()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialClosed()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialClicked()
    {
        if(throughHint)
        {
            GM.instance.watchedAd = true;
            GM.instance.HintPanel();
        }
    }

    public void onNonSkippableVideoLoaded()
    {
        throw new NotImplementedException();
    }

    public void onNonSkippableVideoFailedToLoad()
    {
        throw new NotImplementedException();
    }

    public void onNonSkippableVideoShown()
    {
        throw new NotImplementedException();
    }

    public void onNonSkippableVideoFinished()
    {

        GM.instance.watchedAd = true;
        GM.instance.HintPanel();
    }

    public void onNonSkippableVideoClosed()
    {
        throw new NotImplementedException();
    }
    public void onRewardedVideoLoaded()
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoFailedToLoad()
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoShown()
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoFinished(int amount, string name)
    {

        GM.instance.watchedAd = true;
        GM.instance.HintPanel();
    }

    public void onRewardedVideoClosed()
    {
        throw new NotImplementedException();
    }
#endif
}