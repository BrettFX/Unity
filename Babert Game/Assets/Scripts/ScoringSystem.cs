﻿using UnityEngine;
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
    public GameObject highScoreDisplay;

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
        score += SCORE_DELTA;
        scoreDisplay.GetComponent<Text>().text = "Score: " + score;
    }

    public static void SaveScore()
    {   
        StreamWriter scoreFile = File.CreateText(SAVE_FILE);
        scoreFile.WriteLine(score);
        scoreFile.Close();
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
    }
}
