using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Toggle fullscreen;
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        fullscreen.isOn = Screen.fullScreen;
        List<string> options = new List<string>();

        foreach(Resolution resolution in resolutions){
            string option = resolution.width + " x " + resolution.height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool fullscreen){
        Screen.fullScreen = fullscreen;
    }
}
