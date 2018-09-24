using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    //var for speed
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    [SerializeField]
    private AudioClip _clip;
    private UIManager _uiManager;

    private float _xLimit = 8.4f;
    private float _yLimit = 5.8f;
    private float _startPosition;
    // Use this for initialization
    private void Start ()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        EnemyMovement();
    }
    private void EnemyMovement()
    {
        // move down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //when off the screen randomize spawn on top on the screen
        if (transform.position.y <= -_yLimit)
        {
            _startPosition = Random.Range(-_xLimit, _xLimit);
            transform.position = new Vector3(_startPosition, _yLimit, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            if (_uiManager != null)
            {
                _uiManager.UpdateScore();
            }
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            //access the Player and set powerUp on
            //destroy powerUp
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.LoseLife();
            }
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }

    }
}
