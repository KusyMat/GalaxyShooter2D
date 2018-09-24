using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _spawnManagerPrefab;

    private UIManager _uiManager;

    private SpawnManager _spawnManager;


    public bool gameStarted = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameStarted == false)
        {
            GameStarted();
        }
    }

    public void GameStarted()
    {
        gameStarted = true;
        Instantiate(_playerPrefab, transform.position, Quaternion.identity);
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
        _uiManager.score = 0;
        _uiManager.scoreText.text = "Score: " + _uiManager.score;
        _uiManager.ShowTitleScreen();

    }
}
