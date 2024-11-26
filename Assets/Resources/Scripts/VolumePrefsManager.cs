using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// Summary:
// Set the stored Volume on the different Scenes based on the Player Preference.
public class VolumePrefsManager : MonoBehaviour
{
    private void Start() {
        if (!PlayerPrefs.HasKey("volume")){
            PlayerPrefs.SetFloat("volume", 0.7f);
        }else{
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
        }
    }
}
