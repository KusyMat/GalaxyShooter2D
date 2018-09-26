using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _coopPlayersPrefab;
    [SerializeField]
    private GameObject _spawnManagerPrefab;
    [SerializeField]
    private GameObject _pauseMenu;

    private UIManager _uiManager;

    private SpawnManager _spawnManager;

    public bool coopModeOn = false;
    public bool gameStarted = false;
    public bool gamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameStarted == false)
        {
            GameStarted();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameStarted == false)
        {
            SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.P) && gameStarted == true && gamePaused == false)
        {
            gamePaused = true;
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.P) && gamePaused == true)
        {
            gamePaused = false;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameStarted()
    {
        gameStarted = true;
        if (coopModeOn == false)
        {
            Instantiate(_playerPrefab, transform.position, Quaternion.identity);
        }
        else if (coopModeOn == true)
        {
            Instantiate(_coopPlayersPrefab, transform.position, Quaternion.identity);
        }

        Instantiate(_spawnManagerPrefab, transform.position, Quaternion.identity);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.HideTitleScreen();
    }   

    public void GameOver()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        if (_spawnManager != null)
        {
            Destroy(_spawnManager.gameObject);
        }
        gameStarted = false;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.CheckForTopScore();
        _uiManager.score = 0;
        _uiManager.scoreText.text = "Score: " + _uiManager.score;
        _uiManager.ShowTitleScreen();

    }

    public void ResumeGame()
    {
        gamePaused = false;
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
