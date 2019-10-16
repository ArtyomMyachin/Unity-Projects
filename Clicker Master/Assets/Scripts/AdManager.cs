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
    string appKey = "5f3726a28725b14b5a1d764377cfdbd5c59c98991283102a";
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
        Appodeal.initialize(appKey, Appodeal.BANNER_BOTTOM | Appodeal.INTERSTITIAL);
    }

    // Update is called once per frame
    void Update()
    {
        Appodeal.show(Appodeal.BANNER_BOTTOM);
    }
    public void ShowAd()
    {
        Appodeal.show(Appodeal.INTERSTITIAL);
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void onRewardedVideoClosed()
    {
        throw new NotImplementedException();
    }
#endif
}