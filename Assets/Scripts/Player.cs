using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCooldown;

    private Rigidbody _rb;
    private float _canjump;
    
    // Start is called before the first frame update
    private void Start()
    {
        InitialiseVariables();
        Mouvement();
    }

    private void InitialiseVariables()
    {
        _speed = 10000f;
        _jumpForce = 5f;
        _jumpCooldown = 0.5f;
        _canjump = -1f;


        _rb = this.gameObject.GetComponent<Rigidbody>();
        if (_rb == null)
            Debug.LogError("_rb is null");
    }

    private void Jump()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && Time.time >= _canjump)
        {
            _rb.velocity = new Vector3(_rb.velocity.x,_jumpForce,_rb.velocity.z);;
            _canjump = Time.time + _jumpCooldown;
            Debug.Log("Jump!");
        }
    }

    private void Mouvement() //needs changes
    {
        _rb.AddForce(new Vector3(_speed * Time.deltaTime,0f,0f),ForceMode.Force);
    }

    // Update is called once per frame
    private void Update()
    {
        Jump();
    }
}
