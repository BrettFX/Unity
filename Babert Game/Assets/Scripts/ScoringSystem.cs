using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoringSystem : MonoBehaviour
{
    public enum Platform
    {
        DESKTOP,
        MOBILE
    };

    public static Platform TARGET_PLATFORM = Platform.DESKTOP;

    public const string SAVE_FILE = "highscore.data";
    public const string PREFS_KEY = "HighScore";

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
        saved = false;
        
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
            switch (TARGET_PLATFORM)
            {
                case Platform.DESKTOP:
                    StreamWriter scoreFile = File.CreateText(SAVE_FILE);
                    scoreFile.WriteLine(score);
                    scoreFile.Close();
                    break;
                case Platform.MOBILE:
                    PlayerPrefs.SetInt(PREFS_KEY, score);
                    break;
            }
        }

        saved = true;
    }

    // Create the score file if it does not exist
    public static void CreateScoreFile()
    {
        StreamWriter scoreFile = File.CreateText(SAVE_FILE);
        scoreFile.WriteLine("0");
        scoreFile.Close();
    }

    public void LoadScore()
    {
        switch (TARGET_PLATFORM)
        {
            case Platform.DESKTOP:
                string scoreLoad = "0";
                string line;

                // Try to read highscore and create the score file if it does not exist
                try
                {
                    StreamReader sr = new StreamReader(SAVE_FILE);

                    line = sr.ReadLine();
                    while (line != null)
                    {
                        scoreLoad = line;
                        line = sr.ReadLine();
                    }

                    sr.Close();
                } 
                catch (FileNotFoundException)
                {
                    CreateScoreFile();
                }


                highScore = int.Parse(scoreLoad);
                break;

            case Platform.MOBILE:
                highScore = PlayerPrefs.GetInt(PREFS_KEY, 0);
                break;
        }

        highScoreDisplay.GetComponent<Text>().text = "High Score: " + highScore;
        
    }
}
