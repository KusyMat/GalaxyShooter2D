using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
	// Use this for initialization
	void Start ()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_player.isPlayerOne == true)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _animator.SetBool("TurnLeft", true);
                _animator.SetBool("TurnRight", false);
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _animator.SetBool("TurnLeft", false);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _animator.SetBool("TurnRight", true);
                _animator.SetBool("TurnLeft", false);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                _animator.SetBool("TurnRight", false);
            }
        }
        else if (_player.isPlayerTwo == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                _animator.SetBool("TurnLeft", true);
                _animator.SetBool("TurnRight", false);
            }
            else if (Input.GetKeyUp(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                _animator.SetBool("TurnLeft", false);
            }
            if (Input.GetKeyDown(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                _animator.SetBool("TurnRight", true);
                _animator.SetBool("TurnLeft", false);
            }
            else if (Input.GetKeyUp(KeyCode.PageDown) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                _animator.SetBool("TurnRight", false);
            }
        }
    }
}
