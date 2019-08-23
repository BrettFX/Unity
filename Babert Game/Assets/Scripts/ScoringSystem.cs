using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    private const float INCREASE_RATE = 0.1f; 
    private const int START_DELAY = 0; // In seconds
    private const int SCORE_DELTA = 5; // Set to zero if only collectables should increase score

    public static int score;
    public GameObject scoreDisplay;

    void Start()
    {
        InvokeRepeating("AddScore", START_DELAY, INCREASE_RATE);
    }


    void AddScore()
    {
        score += SCORE_DELTA;
        scoreDisplay.GetComponent<Text>().text = "Score: " + score;
    }
}
