using SimpleHealthBar_SpaceshipExample;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    // Jimmy Vegas Unity Tutorial
    // This script will activate your death screen and deactivate the rocket

    // Game over screen assets //
    [Header("Game Over Screen Assets")]
    public GameObject gameOverScreen;
    public GameObject gameOverText;


    // Audio assets //
    [Header("Audio Assets")]
    public AudioSource crash;
    public GameObject mainAudio;

    // Amount of damange to inflict player when a collision occurs //
    private const int DAMAGE = 20;

    private GameObject rocket;

    private bool m_godmode = false;
    private bool m_noclip = false;

    private void Start()
    {
        rocket = GameObject.FindWithTag("Rocket");

        // Determine if to use cheats (e.g., developer mode enabled)
        if (DeveloperMode.IsDevMode())
        {
            string pref_key = System.Enum.GetName(typeof(DevSettingsManager.DevSetting),
                                               DevSettingsManager.DevSetting.GOD_MODE);
            m_godmode = PlayerPrefs.GetInt(pref_key, 0) != 0;

            pref_key = System.Enum.GetName(typeof(DevSettingsManager.DevSetting),
                                               DevSettingsManager.DevSetting.NO_CLIP);
            m_noclip = PlayerPrefs.GetInt(pref_key, 0) != 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        // Handle God mode if enabled and developer mode is enabled
        if (DeveloperMode.IsDevMode())
        {
            // TODO handle godmode
            if (m_godmode)
            {
                return;
            }

            // TODO handle noclip
            if (m_noclip)
            {
                return;
            }
        }

        // Take some damange
        col.gameObject.GetComponent<PlayerHealth>().TakeDamage(DAMAGE);

        // Set the next axis to the start x so that the initially spawned axis isn't off screen
        //NextAxis.xAxis = NextAxis.START_X;
        //ScoringSystem.SaveScore();

        //// Play crash sound and stop main audio
        //crash.Play();
        //mainAudio.SetActive(false);

        //// Display death screen and give the user the option to restart or go back to main menu
        //gameOverScreen.SetActive(true);
        //rocket.SetActive(false);
    }
}
