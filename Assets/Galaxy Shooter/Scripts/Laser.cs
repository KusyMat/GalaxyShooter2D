using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    private float _yLimit = 5.5f;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // move up with 10 speed
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        
        //if position is greater than 5.5 destroy it
        if (transform.position.y >= _yLimit)
        {
            Destroy(this.gameObject);
            if (transform.parent !=null)
            {
                Destroy(transform.parent.gameObject);
            }
        }
	}
    public void LaserHit()
    {
        Destroy(this.gameObject);
    }
}
