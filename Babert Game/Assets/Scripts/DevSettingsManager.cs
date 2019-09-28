using System;
using UnityEngine;
using UnityEngine.UI;

public class DevSettingsManager : MonoBehaviour
{
    public enum DevSetting
    {
        GRAVITY,
        MOVEMENT_SPEED,
        JUMP_SPEED
    }

    [Serializable]
    public struct Settings
    {
        public DevSetting setting;
        public Slider slider;
    }
    public Settings[] settings;

    private void Start()
    {
        // Load developer settings only if developer mode is enabled
        if (DeveloperMode.IsDevMode())
        {
            Load();
        }
        else
        {
            // Use default dev settings

        }
    }

    public void Load()
    {
        // Initialize settings states; attempt to load from player prefs
        foreach (Settings s in settings)
        {
            s.slider.value = PlayerPrefs.GetFloat(s.setting.ToString(), 1.0f);
            //Debug.Log("Setting: " + s.setting + ", Slider Value: " + s.slider.value);
        }

        Debug.Log("Developer settings loaded.");
    }

    // Save all settings based on settings dictionary to the respective play prefs entry
    public void Save()
    {
        foreach (Settings s in settings)
        {
            //Debug.Log("Setting: " + s.setting + ", Slider Value: " + s.slider.value);
            PlayerPrefs.SetFloat(s.setting.ToString(), s.slider.value);
        }

        Debug.Log("Developer settings saved.");
    }
}
