using HmsPlugin;
using HuaweiMobileServices.Ads;
using HuaweiMobileServices.IAP;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoubleScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void apply2xPoints()
    {
        GameObject cubeDetector = GameObject.Find("CubeDetector");
        int bonus = cubeDetector.GetComponent<CubeDetector>().collectedBonus;
        TextMeshProUGUI text = cubeDetector.GetComponent<CubeDetector>().text;
        bonus *= 2;
        text.text = bonus.ToString();
    }


    private void OnRewarded(Reward reward)
    {
        apply2xPoints();
    }

    public void WatchRewardedAd()
    {
        HMSAdsKitManager.Instance.OnRewarded = OnRewarded;
        HMSAdsKitManager.Instance.ShowRewardedAd();

    }

    public void Buy2XPoints()
    {
        if(!HMSAccountKitManager.Instance.IsSignedIn)
            HMSAccountKitManager.Instance.SignIn();
        HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;
        HMSIAPManager.Instance.PurchaseProduct(HMSIAPConstants._2xPoints);

    }

    private void OnBuyProductSuccess(PurchaseResultInfo result)
    {
        if (result.InAppPurchaseData.ProductId == HMSIAPConstants._2xPoints)
        {
            apply2xPoints();
        }
    }
}
