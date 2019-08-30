using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoringSystem : MonoBehaviour
{
    public static string SAVE_FILE = "highscore.data";

    private const float INCREASE_RATE = 0.1f; 
    private const int START_DELAY = 0; // In seconds
    private const int SCORE_DELTA = 5; // Set to zero if only collectables should increase score

    public static int score;
    public GameObject scoreDisplay;

    void Start()
    {
        // Reset score
        ScoringSystem.score = 0;
        InvokeRepeating("AddScore", START_DELAY, INCREASE_RATE);
    }

    void AddScore()
    {
        score += SCORE_DELTA;
        scoreDisplay.GetComponent<Text>().text = "Score: " + score;
    }

    public static void SaveScore()
    {   
        StreamWriter scoreFile = File.CreateText(SAVE_FILE);
        scoreFile.WriteLine(score);
        scoreFile.Close();
    }
}
