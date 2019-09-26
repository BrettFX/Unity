using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    private const int TRIGGER_COUNT = 10;

    private bool m_devModeEnabled = false;

    private int m_clicks = 0;
    public GameObject developerButton;
    public AudioSource specialSFX;

    // Count number of clicks and enable developer mode
    public void OnClick()
    {
        m_clicks++;
        Debug.Log("Clicked " + m_clicks + " time(s)!");

        int threshold = TRIGGER_COUNT / m_clicks;

        // Play special sound effect if clicks are half of trigger cound
        if (threshold == 2 && threshold != 0 && !m_devModeEnabled)
        {
            specialSFX.Play();
        }

        // Display developer button, enabling developer mode
        if (m_clicks == TRIGGER_COUNT)
        {
            developerButton.SetActive(true);
            m_devModeEnabled = true;
            Debug.Log("Developer mode enabled!");
        }
    }
}
