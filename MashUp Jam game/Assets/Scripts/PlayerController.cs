using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject _gameOver;
    private ShootingController _shootingController;

    private Vector2 _movementInput;
    private int _health = 3;
    private GameObject _waveSpawner;

    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent(out _rigidbody2D))
            Debug.LogError($"Couldn't find Rigidbody2D on {gameObject.name}");
        if(!TryGetComponent(out _shootingController))
            Debug.LogError($"Couldn't find shooting controller on {gameObject}");
    }

    // Update is called once per frame
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
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with Enemy");
            Damaged();
            Destroy(gameObject);
        }
    }

    private void Damaged()
    {
        _health--;
        if (_health == 0)
        {
            _gameOver.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    

}
