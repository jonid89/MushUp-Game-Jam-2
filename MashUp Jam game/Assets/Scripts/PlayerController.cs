using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private ShootingController _shootingController;

    private Vector2 _movementInput;

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

    private void FixedUpdate()
    {
        var movementNormalized = _movementInput.normalized * (movementSpeed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(_rigidbody2D.position + movementNormalized);
    }
}
