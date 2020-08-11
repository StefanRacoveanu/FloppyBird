using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rb;
    private GameManager _gameManager;
    private float _canJump = -1f;
    private int _score = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        InitialiseVariables();
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Teava")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ++_score;
        _gameManager.UpdateScore(_score);
    }

    private void InitialiseVariables()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        if (_rb == null)
            Debug.LogError("_rb is null");

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
            Debug.LogError("_gameManager is NULL!");    
    }

    private void Jump()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && Time.time >= _canJump && GameManager.)
        {
            _rb.velocity = new Vector2(_rb.velocity.x,_jumpForce);;
            _canJump = Time.time + _jumpCooldown;
        }
    }

    private void Rotation()
    {
        float vel = _rb.velocity.y;
        float rot = transform.localEulerAngles.z;
        //Vector3 vector3_rot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        if (vel > 0 && (rot < 45 || rot > 200))
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
        else if (vel < 0 && (rot > 320 || rot < 150))
            transform.Rotate(Vector3.forward, -(_rotationSpeed * Time.deltaTime));
    }

    private void Movement() //needs changes
    {
        _rb.AddForce(new Vector3(_speed,0f,0f),ForceMode2D.Force);
    }

    private void CheckForMapExit()
    {
        if (transform.position.y > 6.5 || transform.position.y < -6.5)
        {
            Destroy(this.gameObject);            
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Jump();
        Rotation();
        CheckForMapExit();
    }
}
