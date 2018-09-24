using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float _xLimit = 8.4f;
    private float _yLimit = 5.8f;
    private float _startPosition;
    [SerializeField]
    private GameObject _enemyShipPrefab;
    [SerializeField]
    private GameObject[] _powerUps;

    private int _enemySpawner = 0;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUp());
    }

    //create a coroutine to spawn enemy every 3 seconds
    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (_enemySpawner <= 10)
            {
                _startPosition = Random.Range(-_xLimit, _xLimit);
                Instantiate(_enemyShipPrefab, new Vector3(_startPosition, _yLimit, 0), Quaternion.identity);
                _enemySpawner++;
                yield return new WaitForSeconds(3.0f);
            }
            if (_enemySpawner > 10 && _enemySpawner <= 20 )
            {
                _startPosition = Random.Range(-_xLimit, _xLimit);
                Instantiate(_enemyShipPrefab, new Vector3(_startPosition, _yLimit, 0), Quaternion.identity);
                _startPosition = Random.Range(-_xLimit, _xLimit);
                Instantiate(_enemyShipPrefab, new Vector3(_startPosition, _yLimit, 0), Quaternion.identity);
                _enemySpawner++;
                yield return new WaitForSeconds(3.0f);
            }
            if (_enemySpawner > 20)
            {
                _startPosition = Random.Range(-_xLimit, _xLimit);
                Instantiate(_enemyShipPrefab, new Vector3(_startPosition, _yLimit, 0), Quaternion.identity);
                _startPosition = Random.Range(-_xLimit, _xLimit);
                Instantiate(_enemyShipPrefab, new Vector3(_startPosition, _yLimit, 0), Quaternion.identity);
                _startPosition = Random.Range(-_xLimit, _xLimit);
                Instantiate(_enemyShipPrefab, new Vector3(_startPosition, _yLimit, 0), Quaternion.identity);
                _startPosition = Random.Range(-_xLimit, _xLimit);
                Instantiate(_enemyShipPrefab, new Vector3(_startPosition, _yLimit, 0), Quaternion.identity);
                _enemySpawner++;
                yield return new WaitForSeconds(3.0f);
            }
        }
    }
    public IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            int randomPowerUp = Random.Range(0, 3);
            _startPosition = Random.Range(-_xLimit, _xLimit);
            Instantiate(_powerUps[randomPowerUp], new Vector3(_startPosition, _yLimit, 0), Quaternion.identity);
            yield return new WaitForSeconds(7.0f);
        }
    }
}
