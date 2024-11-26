using System.Collections;
using System.Collections.Generic;
using System.Net;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Summary:
// Arrange the options.
// It includes the options such as setting volume, setting quality or setting screen resolutions.
public class SettingsMenuUI : MonoBehaviour
{
    public  AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public GameObject volumeSlider;
    private Resolution[] resolutions;

    private void Start() {
        ResolutionSettings();

        if (!PlayerPrefs.HasKey("volume")){
            PlayerPrefs.SetFloat("volume", 0.5f);
        }else{
            volumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume");
        }
    }

    // Set the Volume based on the slider
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

    // Set the Quality based on the dropdown selection
    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // Set the Resolution as full screen based on the toggle
    // If it already is full screen, exit the full screen mode.
    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    // Get the current Resolutions compatible with the players computer
    // Refresh the dropdown options by removing the old options and adding these Resolutions to the dropdown menu
    private void ResolutionSettings(){
        resolutions = Screen.resolutions;
        resolutionDropdown.options.Clear();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i<resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            // NOTE: The resolutions can't be compared directly in an if-statement. 
            // That's why we are comparing their width and height one by one.
            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height ){
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Set the Resolution based on the dropdown selection
    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
