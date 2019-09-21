using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public enum Setting
    {
        MASTER_VOLUME,
        MUSIC,
        SFX,
        DIFFICULTY,
        MOVEMENT
    }

    [Serializable]
    public struct Settings
    {
        public Setting setting;
        public Slider slider;
    }
    public Settings[] settings;

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        // Initialize settings states; attempt to load from player prefs
        foreach (Settings s in settings)
        {
            s.slider.value = PlayerPrefs.GetFloat(s.setting.ToString(), 1.0f);
            //Debug.Log("Setting: " + s.setting + ", Slider Value: " + s.slider.value);
        }

        // Apply settings
        Apply();

        Debug.Log("Settings loaded.");
    }

    // Save all settings based on settings dictionary to the respective play prefs entry
    public void Save()
    {
        foreach (Settings s in settings)
        {
            //Debug.Log("Setting: " + s.setting + ", Slider Value: " + s.slider.value);
            PlayerPrefs.SetFloat(s.setting.ToString(), s.slider.value);
        }

        // Apply settings
        Apply();

        Debug.Log("Settings saved.");
    }

    public static void Apply()
    {
        // Set master volume
        string master_vol_key = System.Enum.GetName(typeof(Setting), Setting.MASTER_VOLUME);
        float master_vol = PlayerPrefs.GetFloat(master_vol_key, 1.0f);
        AudioListener.volume = master_vol;
    }
}
