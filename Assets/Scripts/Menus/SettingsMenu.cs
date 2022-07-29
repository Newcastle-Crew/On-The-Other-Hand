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
    public static event Action<float> OnSensitivityChange;
    private string musicString => GameSettings.musicString;
    private string sfxString => GameSettings.sfxString;
    private string mouseString => GameSettings.mouseString;


    private void Awake()
    {
        //Initialize settings
        musicSlider.value = GameSettings.GetMusicVolume();
        SFXSlider.value = GameSettings.GetSFXVolume();
        mouseSensSlider.value = GameSettings.GetMouseSense();
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
        OnSensitivityChange?.Invoke(sens * GameSettings.mouseSensFactor);
    }

    private void SavePlayerPref(string key, float value)
    {
        if(PlayerPrefs.GetFloat(key, GameSettings.defaultValue) == value) return;
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }
}