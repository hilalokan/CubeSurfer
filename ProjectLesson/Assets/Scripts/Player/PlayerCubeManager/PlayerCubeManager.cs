using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCubeManager : MonoBehaviour
{

    public int levelNumber;

    private float stepLength = 0.8f;
    private float playerStepLength = 1.2f;

    public List<CubeBehaviour> listOfCubeBehaviour = new List<CubeBehaviour>();

    public RectTransform WinUI;
    public RectTransform LoseUI;

    private void Awake()
    {
        Singleton();
    }

    #region Singleton

    public static PlayerCubeManager Instance;

    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

    }

    #endregion

    public void GetCube(CubeBehaviour cubeBehaviour)
    {
        listOfCubeBehaviour.Add(cubeBehaviour);
        cubeBehaviour.isStacked = true;

        cubeBehaviour.transform.parent = transform;

        int indexOfCube = listOfCubeBehaviour.Count - 1;

        RelocatePayer();

        ReorderCubes();

    }

    private void RelocatePayer()
    {
        int indexOfCube = listOfCubeBehaviour.Count - 1;

        var playerTransform = PlayerBehaviour.Instance.transform;
        var yValue = indexOfCube * stepLength + playerStepLength;
        var playerTarget = new Vector3(0f, yValue, 0f);

        playerTransform.DOLocalMove(playerTarget, 0.05f);
    }


    public void DropCube(CubeBehaviour cubeBehaviour)
    {

        cubeBehaviour.transform.parent = null;
        cubeBehaviour.isStacked = false;

        listOfCubeBehaviour.Remove(cubeBehaviour);

        if(listOfCubeBehaviour.Count < 1)
        {
            Debug.Log("Game Over");

            PlayerBehaviour.Instance.FailAnimation();
            PlayerBehaviour.Instance.StopPlayer();

            var playerTransform = PlayerBehaviour.Instance.transform;
            Vector3 groundPosition = new Vector3(0f, 0.41f, -1f);
            playerTransform.DOLocalJump(groundPosition, 0.05f, 1, 0.5f);

            LoseUI.gameObject.SetActive(true);

            return;

        }

        RelocatePayer();



    }

    private void ReorderCubes()
    {

        int index = listOfCubeBehaviour.Count - 1;

        foreach (var cube in listOfCubeBehaviour)
        {
            Vector3 target = new Vector3(0.75f, index * stepLength, 0f);
            cube.transform.DOLocalMove(target, 0.05f);
            index--;
        }

    }

    public void ActivateWinUI()
    {
        WinUI.gameObject.SetActive(true);
        Vector3 defaultScale = WinUI.transform.localScale;
        WinUI.transform.localScale = Vector3.one * 0.00001f;
        WinUI.DOScale(defaultScale, 1f).SetEase(Ease.OutBounce);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(levelNumber);

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(++levelNumber);
        Debug.Log(levelNumber);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }



}
