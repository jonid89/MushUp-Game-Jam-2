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
    [SerializeField] Joystick _joystick;

    private ShootingController _shootingController;

    private Vector2 _movementInput;
    private int _health = 3;
    private float _invincibleTimer = 0;
    private bool _invincible = false;

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        if(!TryGetComponent(out _rigidbody2D))
            Debug.LogError($"Couldn't find Rigidbody2D on {gameObject.name}");
        if(!TryGetComponent(out _shootingController))
            Debug.LogError($"Couldn't find shooting controller on {gameObject}");

        _health = 3;
        _invincible = false;
    }


    void Update()
    {
        //_movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _movementInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        
        if (Input.GetMouseButtonDown(0))
            //_shootingController.Shoot();

        Debug.Log("Invincible timer: " + _invincibleTimer);
        if (_invincible)
        {
            _invincibleTimer -= Time.deltaTime;
            if (_invincibleTimer < 0)
                _invincible = false;
        }
    }

    void FixedUpdate()
    {
        var movementNormalized = _movementInput.normalized * (movementSpeed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(_rigidbody2D.position + movementNormalized);


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) Damaged();
    }

    private void Damaged()
    {
        if (_invincible)
            return;
        else
        {
            _invincibleTimer = _noDamageTime;
            _health = _health - 1;
            FMODUnity.RuntimeManager.PlayOneShot("event:/loose_health"); 
           _invincible = true;
            _lives.GetComponent<Lives>().Damaged();

            Debug.Log("Health: "+_health);

            if (_health == 0)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/game_over");
                _gameOver.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }

}
