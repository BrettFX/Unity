using System;
using System.Collections.Generic;
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

    private Dictionary<DevSetting, float> devSettingDefaults;

    [Serializable]
    public struct Settings
    {
        public DevSetting setting;
        public Slider slider;
    }
    public Settings[] settings;

    public Toggle defaultsToggle;

    private void Start()
    {
        // Build defaults dictionary
        devSettingDefaults = new Dictionary<DevSetting, float>()
        {
            { DevSetting.GRAVITY, Controls.DEFAULT_GRAVITY },
            { DevSetting.MOVEMENT_SPEED, Controls.DEFAULT_SPEED },
            { DevSetting.JUMP_SPEED, Controls.DEFAULT_JUMP_SPEED }
        };

        // Load dev settings
        Load();
    }

    public void Load()
    {
        // Initialize settings states; attempt to load from player prefs
        foreach (Settings s in settings)
        {
            s.slider.value = PlayerPrefs.GetFloat(s.setting.ToString(), devSettingDefaults[s.setting]) / 100;
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
            PlayerPrefs.SetFloat(s.setting.ToString(), s.slider.value * 100);
        }

        Debug.Log("Developer settings saved.");
    }

    // Restores state of slider values between defaults and currently saved settings in player prefs
    public void ToggleDefaults()
    {
        Debug.Log("Toggle state: " + defaultsToggle.isOn);

        // Load default values if on; load currently saved values if off
        foreach (Settings s in settings)
        {
            s.slider.value = defaultsToggle.isOn ? 
                devSettingDefaults[s.setting] / 100 :
                PlayerPrefs.GetFloat(s.setting.ToString(), devSettingDefaults[s.setting]) / 100;
        }
    }
}
