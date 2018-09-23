using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private int powerUpID;// 0 = triple shot, 1 = speed boost, 2 = shield
    [SerializeField]
    private AudioClip _clip;

    private float _yLimit = -5.5f;
    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= _yLimit)
        {
            Destroy(this.gameObject);
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            //access the Player and set powerUp on
            //destroy powerUp
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {

                if (powerUpID == 0)
                {
                    //enable triple shot
                    player.TripleShotPowerUpOn();
                }
                else if (powerUpID == 1)
                {
                    //enable speed boost
                    player.SpeedBoostOn();
                }
                else if (powerUpID == 2)
                {
                    //enable shield
                    player.ShieldPowerUpOn();
                }
            }
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
