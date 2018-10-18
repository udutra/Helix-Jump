using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public static LevelController instance; //Padrão singleton
    private int score;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    
    private void Awake()
    {
        instance = this;
        gameOver = false;
    }

    public void SetScore()
    {
        score++;
        if(scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
