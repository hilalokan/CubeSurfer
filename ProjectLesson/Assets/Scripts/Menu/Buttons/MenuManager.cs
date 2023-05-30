using HmsPlugin;
using HuaweiMobileServices.IAP;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public RectTransform SettingsBG;

    private void Awake()
    {
    }

    private void Start()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void onRemoveAdsClick()
    {

        PlayerCubeManager.Instance.hideAds = true;

        HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;
        HMSIAPManager.Instance.PurchaseProduct(HMSIAPConstants.RemoveAds);
    }

    private void OnBuyProductSuccess(PurchaseResultInfo result)
    {
        if(result.InAppPurchaseData.ProductId == HMSIAPConstants.RemoveAds)
        {
            Debug.Log("ads removed");
            PlayerCubeManager.Instance.hideAds = true;
        }
    }

}
