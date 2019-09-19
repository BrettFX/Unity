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
        // Initialize settings states; attempt to load from player prefs
        foreach (Settings s in settings)
        {
            s.slider.value = PlayerPrefs.GetFloat(s.setting.ToString(), 1.0f);
            Debug.Log("Setting: " + s.setting + ", Slider Value: " + s.slider.value);
        }
    }

    // Save all settings based on settings dictionary to the respective play prefs entry
    public void Save()
    {
        foreach (Settings s in settings)
        {
            //Debug.Log("Setting: " + s.setting + ", Slider Value: " + s.slider.value);
            PlayerPrefs.SetFloat(s.setting.ToString(), s.slider.value);
        }

        Debug.Log("Settings saved.");
    }
}
