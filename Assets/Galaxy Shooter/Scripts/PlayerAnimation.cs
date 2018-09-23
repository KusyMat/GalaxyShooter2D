using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
	// Use this for initialization
	void Start ()
    {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetBool("TurnLeft", true);
            _animator.SetBool("TurnRight", false);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("TurnLeft", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool("TurnRight", true);
            _animator.SetBool("TurnLeft", false);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("TurnRight", false);
        }
	}
}
