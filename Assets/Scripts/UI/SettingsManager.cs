using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{


    Resolution[] resolutions;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI deathRateText;
    [SerializeField] TextMeshProUGUI reloadTimeText;
    [SerializeField] TextMeshProUGUI maxScoreText;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] Slider Volume;
    [SerializeField] Toggle fullScreen;
    [SerializeField] TMP_Dropdown qualt;
    [SerializeField] Toggle Processing;
    [SerializeField] Slider DeathRate;
    [SerializeField] Slider Speed;
    [SerializeField] Slider Reload;
    [SerializeField] Slider Score;
    MenuManager menuManager;

    private void Start()
    {
        Volume.value = PlayerPrefs.GetFloat("Volume", 0);
        int f = PlayerPrefs.GetInt("isFullScreen", 1);
        if (f == 1)
            fullScreen.isOn = true;
        else
            fullScreen.isOn = false;
        int g = PlayerPrefs.GetInt("isProcessing", 2);
        if (g == 2)
            Processing.isOn = true;
        else
            Processing.isOn = false;
        DeathRate.value = PlayerPrefs.GetInt("deathRate", 10);
        Speed.value = PlayerPrefs.GetInt("speed", 10);
        Reload.value = PlayerPrefs.GetInt("reloadTime", 3);
        Score.value = PlayerPrefs.GetInt("maxScore", 5);

        menuManager = GetComponent<MenuManager>();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();


        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.value = PlayerPrefs.GetInt("resolutionIndex", 0);

        qualt.value = PlayerPrefs.GetInt("Quality", 0);

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (isFullScreen)
            PlayerPrefs.SetInt("isFullScreen", 1);
        else
            PlayerPrefs.SetInt("isFullScreen", 0);
    }
    public void SetPostProcessing(bool isProcessing)
    {
        if (isProcessing)
            PlayerPrefs.SetInt("isProcessing", 2);
        else
            PlayerPrefs.SetInt("isProcessing", 1);

    }
    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetSpeedSlider(float speed)
    {
        speedText.SetText(speed.ToString());
        PlayerPrefs.SetInt("speed", (int)speed);
    }
    public void SetDeathRateSlider(float deathRate)
    {
        deathRateText.SetText(deathRate.ToString());
        PlayerPrefs.SetInt("deathRate", (int)deathRate);
    }
    public void setReloadTimeSlider(float reloadTime)
    {
        reloadTimeText.SetText(reloadTime.ToString());
        PlayerPrefs.SetInt("reloadTime", (int)reloadTime);
    }
    public void SetMaxScoreSlider(float score)
    {
        maxScoreText.SetText(score.ToString());
        PlayerPrefs.SetInt("maxScore", (int)score);
    }
    public void deleteData()
    {
        PlayerPrefs.DeleteAll();
        menuManager.NextScene(0);
    }
}
