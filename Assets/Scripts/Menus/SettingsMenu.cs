#region 'Using' information
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
#endregion

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;   // The mixer that controls music volume.
    [SerializeField] private AudioMixer SFXMixer;     // The mixer that controls sound effect volume.
    [SerializeField] private Slider musicSlider; // The slider that controls music volume.
    [SerializeField] private Slider SFXSlider; // The slider that controls sound effect volume.
    [SerializeField] private Slider mouseSensSlider; //The slider that controls mouse sensitivity

    public static float mouseSens;
    private float mouseSensFactor = 10f; //Chosen by using the default value of the FirstPersonAIO script
    public const string musicString = "musicVolume";
    public const string sfxString = "SFXVolume";
    public const string mouseString = "mouseSens";
    private const float defaultValue = 0.5f; //Used as default value if the player prefs key isn't found

    public static event Action<float> OnSensitivityChange;


    private void Awake()
    {
        //Initialize settings
        musicSlider.value = PlayerPrefs.GetFloat(musicString, defaultValue);
        SetMusicVolume(musicSlider.value);

        SFXSlider.value = PlayerPrefs.GetFloat(sfxString, defaultValue);
        SetSFXVolume(SFXSlider.value);

        mouseSensSlider.value = PlayerPrefs.GetFloat(mouseString, defaultValue);
        SetMouseSens(mouseSensSlider.value);
    }

    public void SetMusicVolume(float musicVol)
    {
        SavePlayerPref(musicString, musicVol); // Sets the value of SliderVolume to the music volume value.
        if (musicVol <= 0)
            musicMixer.SetFloat(musicString, 0); //Avoid mathematical errors with Mathf.Log10(0);
        else 
            musicMixer.SetFloat(musicString, Mathf.Log10(musicVol) * 20);
    }

    public void SetSFXVolume(float sfxVol)
    {
        SavePlayerPref(sfxString, sfxVol);
        if (sfxVol <= 0)
            SFXMixer.SetFloat(sfxString, 0);
        else 
            SFXMixer.SetFloat(sfxString, Mathf.Log10(sfxVol) * 20);
    }

    public void SetMouseSens(float sens)
    {
        SavePlayerPref(mouseString, sens);
        mouseSens = sens * mouseSensFactor;
        OnSensitivityChange?.Invoke(mouseSens);
    }

    private void SavePlayerPref(string key, float value)
    {
        if(PlayerPrefs.GetFloat(key, defaultValue) == value) return;
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }
}