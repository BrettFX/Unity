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
        JUMP_SPEED,
        GOD_MODE,
        NO_CLIP
    }

    private Dictionary<DevSetting, float> devSettingDefaults;

    [Serializable]
    public struct Settings
    {
        public DevSetting setting;
        public Slider slider;
        public Toggle checkbox;
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
            // Determine the type of setting to load (e.g., slider, checkbox, ect.)
            if (s.slider != null)
            {
                s.slider.value = PlayerPrefs.GetFloat(s.setting.ToString(), devSettingDefaults[s.setting]) / 100;
                //Debug.Log("Setting: " + s.setting + ", Slider Value: " + s.slider.value);
            }

            if (s.checkbox != null)
            {
                // Grab saved checkbox value from player prefs
                s.checkbox.isOn = PlayerPrefs.GetInt(s.setting.ToString(), 0) != 0;
            }

        }

        Debug.Log("Developer settings loaded.");
    }

    // Save all settings based on settings dictionary to the respective play prefs entry
    public void Save()
    {
        foreach (Settings s in settings)
        {
            // Determine the type of setting (e.g., slider, checkbox, etc.) and save the respective value accordingly
            if (s.slider != null)
            {
                //Debug.Log("Setting: " + s.setting.ToString() + ", Slider Value: " + s.slider.value);
                PlayerPrefs.SetFloat(s.setting.ToString(), s.slider.value * 100);
            }
            
            if (s.checkbox != null)
            {
                Debug.Log("Saving checkbox state for: " + s.setting.ToString() + "; state = " + s.checkbox.isOn);
                PlayerPrefs.SetInt(s.setting.ToString(), s.checkbox.isOn ? 1 : 0);
            }
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
            if (devSettingDefaults.ContainsKey(s.setting))
            {
                s.slider.value = defaultsToggle.isOn ?
                   devSettingDefaults[s.setting] / 100 :
                   PlayerPrefs.GetFloat(s.setting.ToString(), devSettingDefaults[s.setting]) / 100;
            }
            else
            {
                Debug.Log(s.setting + " not in the defaults dictionary");
            }
           
        }
    }
}
