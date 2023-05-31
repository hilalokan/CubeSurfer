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
    private GameObject removeAdsButton;

    private void Awake()
    {
        Singleton();
        removeAdsButton = GameObject.Find("RemoveAds");
    }

    private void checkPurchases()
    {
        HMSIAPManager.Instance.RestoreOwnedPurchases((restoredProducts) =>
        {
            foreach (var item in restoredProducts.InAppPurchaseDataList)
            {
                if (item.ProductId == HMSIAPConstants.RemoveAds)
                {
                    Debug.Log("purchase restored, ads removed");
                    hideAds = true;
                    removeAdsButton.SetActive(false);
                }
            }
        });
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
        checkPurchases();
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
            checkPurchases();
        }
    }

}
