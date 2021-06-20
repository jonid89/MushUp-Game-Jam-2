using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float speed = 2f;
    private Transform _playerTransform;
    private Transform _transform;

    private void Awake()
    {
        _playerTransform = GameObject.Find("Player").transform;
    }

    void Start()
    {
        _transform = this.transform;
    }



    void Update()
    {
        transform.right = _playerTransform.position - _transform.position;
        Vector2.MoveTowards(_transform.position, _playerTransform.position, speed * Time.deltaTime);
    }
}
