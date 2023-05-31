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
    public bool hideAds = false;

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static MenuManager Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

    }

    #endregion

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

        HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;
        HMSIAPManager.Instance.PurchaseProduct(HMSIAPConstants.RemoveAds);
    }

    private void OnBuyProductSuccess(PurchaseResultInfo result)
    {
        if(result.InAppPurchaseData.ProductId == HMSIAPConstants.RemoveAds)
        {
            Debug.Log("ads removed");
            hideAds = true;
        }
    }

}
