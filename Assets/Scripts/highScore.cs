using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class highScore : MonoBehaviour
{
    public TextMeshProUGUI highestScore;

    private distanceMeter newDistanceMeter;

    private int highestScoreInt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newDistanceMeter = FindAnyObjectByType<distanceMeter>();
        highestScoreInt = PlayerPrefs.GetInt("PB", 0);
        UpdateUI();
    }

    // Update is called once per frame
    void Update() { }

    public void keepHighScore()
    {
        int actualDistanceInt = Mathf.FloorToInt(newDistanceMeter.Distance);
        if (actualDistanceInt >= highestScoreInt)
        {
            highestScoreInt = actualDistanceInt;
            PlayerPrefs.SetInt("PB", highestScoreInt);
            PlayerPrefs.Save();
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        highestScore.text = "PB: " + highestScoreInt.ToString("D6");
    }
}
