using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject btnPause;
    public GameObject mainAudio;

    public static bool paused = false;

    // Place an overlay on the play screen containing the associated assets for the pause menu
    public void Pause()
    {
        paused = true;
        pauseScreen.SetActive(true);
        btnPause.SetActive(false);
        AudioListener.volume = AudioListener.volume * 0.25f;
    }

    public void Restart()
    {
        paused = false;
        // Set the next axis to the start x so that the initially spawned axis isn't off screen
        NextAxis.xAxis = NextAxis.START_X;
        pauseScreen.SetActive(false);
        btnPause.SetActive(true);
        SettingsManager.Apply(); // Set audio components back to default based on saved settings
        SceneManager.LoadScene(2);
    }

    public void Play()
    {
        paused = false;
        pauseScreen.SetActive(false);
        btnPause.SetActive(true);
        SettingsManager.Apply(); // Set audio components back to default based on saved settings
    }

    public void Quit()
    {
        paused = false;
        // Set the next axis to the start x so that the initially spawned axis isn't off screen
        NextAxis.xAxis = NextAxis.START_X;
        pauseScreen.SetActive(false);
        btnPause.SetActive(true);
        SettingsManager.Apply(); // Set audio components back to default based on saved settings
        SceneManager.LoadScene(0);
    }
}
