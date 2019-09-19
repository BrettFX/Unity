using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private const string AUDIO_MUTED_KEY = "AudioMuteState";

    private bool m_volumeToggle = true;

    public Button btnVolume;
    public Sprite spriteVolOn;
    public Sprite spriteVolOff;

    public AudioSource mainAudio;
    public AudioSource crash;
    public AudioSource starSound;

    // Start is called before the first frame update
    void Start()
    {
        // Load settings saved in player prefs
        string[] settings = System.Enum.GetNames(typeof(SettingsManager.Setting));
        foreach (string setting in settings)
        {
            Debug.Log("Setting: " + setting + ", Value: " + PlayerPrefs.GetFloat(setting, 1.0f));
        }

        // Get boolean state of audio muting flag (logically convert int to bool)
        m_volumeToggle = (PlayerPrefs.GetInt(AUDIO_MUTED_KEY, 1) != 0);
        SetVolumeState();
    }

    // Toggle the volume state
    public void ToggleVolumeState()
    {
        m_volumeToggle = !m_volumeToggle;
        SetVolumeState();

        // Save the mute state in player prefs so it can be re-loaded at the beginning of another game
        PlayerPrefs.SetInt(AUDIO_MUTED_KEY, m_volumeToggle ? 1 : 0);
    }

    private void SetVolumeState()
    {
        Sprite targetSprite = m_volumeToggle ? spriteVolOn : spriteVolOff;
        btnVolume.GetComponent<Image>().sprite = targetSprite;

        // Toggle audio assets mute/unmute (needs to be inverse of volume toggle state)
        mainAudio.mute = !m_volumeToggle;
        crash.mute = !m_volumeToggle;
        starSound.mute = !m_volumeToggle;
    }
}
