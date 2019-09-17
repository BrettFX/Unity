using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public enum Setting
    {
        MASTER_VOLUME,
        MUSIC,
        SFX
    }

    // Private player prefs keys
    private const string MASTER_VOLUME_KEY = "MasterVolume";
    private const string MUSIC_KEY = "Music";
    private const string SFX_KEY = "SFX";

    [Serializable]
    public struct Settings
    {
        public Setting setting;
        public Slider slider;
    }
    public Settings[] settings;

    private void Start()
    {
        // Initialize settings states; attempt to load from player prefs

    }

    // Save all settings based on settings dictionary to the respective play prefs entry
    public void Save()
    {
        foreach (Settings s in settings)
        {
            Debug.Log("Setting: " + s.setting + ", Slider Value: " + s.slider.value);
            PlayerPrefs.SetFloat(s.setting.ToString(), s.slider.value);
        }
    }
}
