using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public enum AudioSetting
    {
        MASTER_VOLUME,
        MUSIC,
        SFX
    }

    private Dictionary<AudioSetting, float> audioSettingDefaults;

    [Serializable]
    public struct Settings
    {
        public AudioSetting audioSetting;
        public Slider slider;
    }
    public Settings[] settings;

    public Toggle defaultsToggle;

    private void Start()
    {
        audioSettingDefaults = new Dictionary<AudioSetting, float>()
        {
            { AudioSetting.MASTER_VOLUME, SoundManager.DEFAULT_MASTER_VOL },
            { AudioSetting.MUSIC, SoundManager.DEFAULT_MUSIC_VOL },
            { AudioSetting.SFX, SoundManager.DEFAULT_SFX_VOL }
        };

        Load();
    }

    public void Load()
    {
        // Initialize settings states; attempt to load from player prefs
        foreach (Settings s in settings)
        {
            s.slider.value = PlayerPrefs.GetFloat(s.audioSetting.ToString(), 1.0f);
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
            PlayerPrefs.SetFloat(s.audioSetting.ToString(), s.slider.value);
        }

        // Apply settings
        Apply();

        Debug.Log("Settings saved.");
    }

    public static void Apply()
    {
        // Set master volume
        string master_vol_key = System.Enum.GetName(typeof(AudioSetting), AudioSetting.MASTER_VOLUME);
        float master_vol = PlayerPrefs.GetFloat(master_vol_key, 1.0f);
        AudioListener.volume = master_vol;
    }

    public void ToggleAudioDefaults()
    {
        Debug.Log("Toggle state: " + defaultsToggle.isOn);

        // Load default values if on; load currently saved values if off
        foreach (Settings s in settings)
        {
            s.slider.value = defaultsToggle.isOn ?
                audioSettingDefaults[s.audioSetting] :
                PlayerPrefs.GetFloat(s.audioSetting.ToString(), audioSettingDefaults[s.audioSetting]);
        }
    }
}
