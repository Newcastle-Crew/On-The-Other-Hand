using UnityEngine;

public static class GameSettings
{
    public const float mouseSensFactor = 10f; //Chosen by using the default value of the FirstPersonAIO script
    public const string musicString = "musicVolume";
    public const string sfxString = "SFXVolume";
    public const string mouseString = "mouseSens";
    public const float defaultValue = 0.5f; //Used as default value if the player prefs key isn't found

    public static float GetMusicVolume() => PlayerPrefs.GetFloat(musicString, defaultValue);
    public static float GetSFXVolume() => PlayerPrefs.GetFloat(sfxString, defaultValue);
    public static float GetMouseSense() => PlayerPrefs.GetFloat(mouseString, defaultValue) * mouseSensFactor;
}
