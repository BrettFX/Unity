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
    public static int highScore = 0;
    public GameObject scoreDisplay;
    public GameObject highScoreDisplay;

    private static bool saved = false;

    void Start()
    {
        // Load high score
        LoadScore();
        
        // Reset score
        ScoringSystem.score = 0;
        InvokeRepeating("AddScore", START_DELAY, INCREASE_RATE);
    }

    void AddScore()
    {
        // Only add score if the score has not already been saved (indicating gameover)
        if (!saved)
        {
            scoreDisplay.GetComponent<Text>().text = "Score: " + score;
            highScoreDisplay.GetComponent<Text>().text = "High Score: " + highScore;

            score += SCORE_DELTA;

            // Update highscore when the current score exceeds the highscore
            if (score >= highScore)
            {
                highScore = score;
            }
        }
    }

    // Save score only if a new highscore was met
    public static void SaveScore()
    {
        if (highScore == score)
        {
            StreamWriter scoreFile = File.CreateText(SAVE_FILE);
            scoreFile.WriteLine(score);
            scoreFile.Close();           
        }

        saved = true;
    }

    public void LoadScore()
    {
        string scoreLoad = "0"; 
        string line;

        StreamReader sr = new StreamReader(SAVE_FILE);

        line = sr.ReadLine();
        while (line != null)
        {
            scoreLoad = line;
            line = sr.ReadLine();
        }

        sr.Close();

        highScoreDisplay.GetComponent<Text>().text = "High Score: " + scoreLoad;
        highScore = int.Parse(scoreLoad);
    }
}
