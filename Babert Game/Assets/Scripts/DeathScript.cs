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
        NextAxis.xAxis = NextAxis.START_X;

        ScoringSystem.SaveScore();

        // Play crash sound and stop main audio
        crash.Play();
        mainAudio.SetActive(false);

        gameOverScreen.SetActive(true);
        gameOverText.SetActive(true);
        rocket.SetActive(false);
    }
}
