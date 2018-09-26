using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Image titleScreen;
    public Text scoreText;
    public int score = 0;

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 100;
        scoreText.text = "Score: " + score;
    }

    public void ShowTitleScreen()
    {
        titleScreen.enabled = true;
    }

    public void HideTitleScreen()
    {
        titleScreen.enabled = false;
    }

    public void ExitToMainMenu()
    {
        Debug.Log("Main Menu is loading...");
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }

    public void ReturnToGame()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.ResumeGame();
    }
}
