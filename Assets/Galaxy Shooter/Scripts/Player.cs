using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool tripleShot = false;
    public bool speedBoost = false;
    public bool shieldOn = false;

    private float _yLimit = 4.2f;
    private float _xLimit = 9.4f;

    [SerializeField]
    private int playerLife;

    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _Shield;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject[] _engines;
    // fireRate is 0.25f
    //canFire == has the fireRate passed? 
    //Time.time -> how much time in game has passed
    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;


    [SerializeField]
    private float _speed = 5.0f;

    private float _speedBoost = 2.5f;
    // Use this for initialization

    private UIManager _uiManager;
    private GameManager _gameManager;
    private AudioSource _audioSource;

	private void Start ()
    {
        // current pos = new position
        transform.position = new Vector3(0, 0, 0);
        playerLife = 3;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(playerLife);
        }
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
	}

    private void PlayerMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        if (speedBoost == true)
        {
            transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime * _speedBoost);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime * _speedBoost);
        }
        else if (speedBoost == false)
        {
            transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
            transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        }
        // 4,2 y, 8.4 x 
        //If player pos on y is greater than 4.2 stop him from going on
        //If player pos on x is greater than 8.4 stop him from going on
        if (transform.position.y > _yLimit)
        {
            transform.position = new Vector3(transform.position.x, _yLimit, 0);
        }
        else if (transform.position.y < -_yLimit)
        {
            transform.position = new Vector3(transform.position.x, -_yLimit, 0);
        }
        if (transform.position.x > _xLimit)
        {
            transform.position = new Vector3(-_xLimit, transform.position.y, 0);
        }
        else if (transform.position.x < -_xLimit)
        {
            transform.position = new Vector3(_xLimit, transform.position.y, 0);
        }
    }

    private void FireLaser()
    {
        if (Time.time > _canFire)
        {
            _audioSource.Play();
            if (tripleShot == false)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.81f, 0), Quaternion.identity);
                _canFire = Time.time + _fireRate;
            }
            else if (tripleShot == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
                _canFire = Time.time + _fireRate;
            }
        }     
    }

    public void TripleShotPowerUpOn()
    {
        tripleShot = true;
        StartCoroutine(TripleShotPowerUpExhaustion());
    }
    public void SpeedBoostOn()
    {
        speedBoost = true;
        StartCoroutine(SpeedBoostExhaustion());
    }
    public void ShieldPowerUpOn()
    {
        shieldOn = true;
        _Shield.SetActive(true);
    }
    public IEnumerator TripleShotPowerUpExhaustion()
    {
        yield return new WaitForSeconds(5.0f);
        tripleShot = false;
    }
    public IEnumerator SpeedBoostExhaustion()
    {
        yield return new WaitForSeconds(5.0f);
        speedBoost = false;
    }
    public void LoseLife()
    {
        if (shieldOn == true)
        {
            shieldOn = false;
            _Shield.SetActive(false);
        }
        else
        {
            playerLife = playerLife - 1;
            _uiManager.UpdateLives(playerLife);
            if (playerLife == 2)
            {
                _engines[0].SetActive(true);
            }
            else if (playerLife == 1)
            {
                _engines[1].SetActive(true);
            }
        }
        if (playerLife == 0)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _gameManager.GameOver();
            Destroy(this.gameObject);
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}

