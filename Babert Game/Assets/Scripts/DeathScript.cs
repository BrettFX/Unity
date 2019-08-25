using UnityEngine;

public class DeathScript : MonoBehaviour
{
    // Jimmy Vegas Unity Tutorial
    // This script will activate your death screen and deactivate the rocket

    public GameObject gameOverScreen;
    public GameObject gameOverText;
    public GameObject rocket;

    void OnTriggerEnter(Collider col)
    {
        gameOverScreen.SetActive(true);
        gameOverText.SetActive(true);
        rocket.SetActive(false);
    }
}
