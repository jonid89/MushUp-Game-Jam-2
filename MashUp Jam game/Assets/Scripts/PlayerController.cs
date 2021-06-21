using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _lives;
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private float _noDamageTime = 3f;
    
    private ShootingController _shootingController;

    private Vector2 _movementInput;
    private int _health = 3;
    private float _invincibleTimer;
    private bool _invincible = true;

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        if(!TryGetComponent(out _rigidbody2D))
            Debug.LogError($"Couldn't find Rigidbody2D on {gameObject.name}");
        if(!TryGetComponent(out _shootingController))
            Debug.LogError($"Couldn't find shooting controller on {gameObject}");

        _health = 3;
    }


    void Update()
    {
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(Input.GetMouseButtonDown(0))
            _shootingController.Shoot();
        
    }

    void FixedUpdate()
    {
        var movementNormalized = _movementInput.normalized * (movementSpeed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(_rigidbody2D.position + movementNormalized);


        if (_invincible)
        {
            _invincibleTimer -= Time.fixedDeltaTime;
            if (_invincibleTimer < 0)
                _invincible = false;
        }
        Debug.Log(_invincibleTimer);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) Damaged();
    }

    private void Damaged()
    {
        if (_invincible)
            return;

        _invincibleTimer = _noDamageTime;
        _health = _health - 1;
        _lives.GetComponent<Lives>().Damaged();

        if (_health == 0)
        {
            _gameOver.SetActive(true);
            Destroy(this.gameObject);
        }
    }

}
