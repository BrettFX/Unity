using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    private const string DEV_MODE_KEY = "DeveloperMode";
    private const int TRIGGER_COUNT = 5;

    private static bool m_devModeEnabled;

    private int m_clicks = 0;
    public GameObject developerButton;

    public AudioSource inSFX;
    public AudioSource outSFX;

    public void Start()
    {
        m_clicks = 0;

        // Get developer mode state from player prefs
        m_devModeEnabled = PlayerPrefs.GetInt(DEV_MODE_KEY, 0) != 0;
        developerButton.SetActive(m_devModeEnabled);
    }

    // Count number of clicks and enable developer mode
    public void OnClick()
    {
        m_clicks++;
        Debug.Log("Clicked " + (m_clicks % TRIGGER_COUNT) + " time(s) out of " + TRIGGER_COUNT);

        // Play special sound effect if clicks are half of trigger cound
        // m_clicks >= TRIGGER_COUNT / 2 && m_clicks <= TRIGGER_COUNT
        if (m_clicks % TRIGGER_COUNT == 0)
        {
            // Toggle developer button, enabling/disabling developer mode
            m_devModeEnabled = !m_devModeEnabled;
            developerButton.SetActive(m_devModeEnabled);

            // Play the respective sound effect
            if (m_devModeEnabled) inSFX.Play(); else outSFX.Play();

            // Save state to player prefs
            PlayerPrefs.SetInt(DEV_MODE_KEY, m_devModeEnabled ? 1 : 0);
        }
    }

    public static bool IsDevMode()
    {
        return PlayerPrefs.GetInt(DEV_MODE_KEY, 0) != 0;
    }
}
