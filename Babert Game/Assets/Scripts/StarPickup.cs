using UnityEngine;

public class StarPickup : MonoBehaviour
{
    // Jimmy Vegas Unity Tutorial
    // This Script will allow you to collect your star

    public int starScore = 500;
    public AudioSource starSound;

    void OnTriggerEnter(Collider col)
    {
        starSound.Play();
        ScoringSystem.score += starScore;

        // Place the object (transform) that is attached off the screen (1000 units on the y-axis)
        this.transform.position = new Vector3(0, 1000, 0);
    }
}
