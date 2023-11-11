using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpStrength;
    private Rigidbody2D _rigidbody2d;
    private Vector2 _moveInput;
    private float _leftRight;
    private Vector2 _jumpInput;
    private bool _isJumping = false;
    private bool _inAir = false;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 currentMovement = _rigidbody2d.velocity;
        currentMovement.x = _leftRight;
        _rigidbody2d.velocity = currentMovement;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("On Ground");
        _inAir = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //print("In Air");
        _inAir = true;
    }


    void OnMovement(InputValue l_value)
    {
        //print("MOVE: " + l_value.Get<Vector2>());
        _moveInput = l_value.Get<Vector2>() * _speed;
        _leftRight = _moveInput.x;
    }

    void OnJump(InputValue l_value)
    {
        //print("Jump:" + l_value.isPressed);
        if (l_value.isPressed)
        {
            _jumpInput = new Vector2(0, _jumpStrength);
            _isJumping = true;
        }
        else
        {
            _jumpInput = new Vector2(0, 0);
            _isJumping = false;
        }
        if(_inAir == false) _rigidbody2d.velocity += _jumpInput;
    }
}
