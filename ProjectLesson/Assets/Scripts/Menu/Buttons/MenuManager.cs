using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public TextMeshProUGUI volumePercentageText;

    public RectTransform SettingsBG;

    public int sceneNumber;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        SetNumberText(slider.value);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetNumberText(float value)
    {
        var intValue = (int) value;
        volumePercentageText.text = intValue.ToString();
    }

    public void CloseSettings()
    {
        SettingsBG.gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        SettingsBG.gameObject.SetActive(true);
    }

}
