using UnityEngine;

public class DeathScript : MonoBehaviour
{
    // Jimmy Vegas Unity Tutorial
    // This script will activate your death screen and deactivate the rocket

    public GameObject gameOverScreen;
    public GameObject gameOverText;
    public GameObject rocket;

    public AudioSource crash;
    public GameObject mainAudio;

    void OnTriggerEnter(Collider col)
    {
        // Set the next axis to the start x so that the initially spawned axis isn't off screen
        NextAxis.xAxis = NextAxis.START_X;
        ScoringSystem.SaveScore();

        // Play crash sound and stop main audio
        crash.Play();
        mainAudio.SetActive(false);

        // Display death screen and give the user the option to restart or go back to main menu
        gameOverScreen.SetActive(true);
        rocket.SetActive(false);
    }
}
