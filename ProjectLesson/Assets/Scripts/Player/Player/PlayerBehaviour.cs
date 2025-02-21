using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuaweiMobileServices.Ads;
using HmsPlugin;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator animatorOfPlayer;

    public PlayerMoverRunner PlayerMoverRunner;

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static PlayerBehaviour Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

    }

    #endregion

    public void SuccessAnimation()
    {
        animatorOfPlayer.SetTrigger("Victory");
    }

    public void FailAnimation()
    {
        animatorOfPlayer.SetTrigger("Fail");
    }

    public void StopPlayer()
    {
        PlayerMoverRunner.velocity = 0;
        PlayerBehaviour.Instance.PlayerMoverRunner.CanMotion = false;
    }

}
