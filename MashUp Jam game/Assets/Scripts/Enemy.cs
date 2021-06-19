using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float speed = 2f;
    private Vector3 _playerTransformPosition;
    private Vector3 _transformPosition;

    private void Awake()
    {
        _playerTransformPosition = GameObject.Find("Player").transform.position;
    }

    void Start()
    {
        _transformPosition = transform.position;
    }



    void Update()
    {
        transform.LookAt(_playerTransformPosition);
        Vector2.MoveTowards(_transformPosition, _playerTransformPosition, speed * Time.deltaTime);
    }
}
