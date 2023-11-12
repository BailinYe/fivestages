using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            _inAir = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            _inAir = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Water")
        {
            _inAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("On Ground");
        if(collision.transform.tag == "Ground")
        {
            _inAir = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //print("On Ground");
        if (collision.transform.tag == "Ground")
        {
            _inAir = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //print("In Air");
        if (collision.transform.tag == "Ground") _inAir = true;
    }

    public void StopInput()
    {
        GetComponent<PlayerInput>().currentActionMap.Disable();
    }
    public void StartInput()
    {
        GetComponent<PlayerInput>().currentActionMap.Enable();
    }
    void OnMovement(InputValue l_value)
    {
        //print("MOVE: " + l_value.Get<Vector2>());
        _moveInput = l_value.Get<Vector2>() * _speed;
        _leftRight = _moveInput.x;
    }

    void OnJump(InputValue l_value)
    {
        if (_inAir) return;
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

    void OnQuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
