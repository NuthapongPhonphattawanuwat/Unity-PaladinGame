using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    public int score;
    
    public void UpdateScore(int currentScore)
    {
        if (SceneManager.GetActiveScene().name == "CreditScene" || SceneManager.GetActiveScene().name == "MainMenuScene" || SceneManager.GetActiveScene().name == "LoadingScene" || SceneManager.GetActiveScene().name == "CreditScene2" ||SceneManager.GetActiveScene().name == "WinScene"||SceneManager.GetActiveScene().name == "LoseScene")
        {
            _scoreText.enabled = false;
        }
        else
        {
            _scoreText.enabled = true;
        }
        _scoreText.text = "Health Potion Collected : " + currentScore;
        score = currentScore;
    }

    private void Update()
    {
        ScoreManager.instance.AddScore(0);
    }
}
