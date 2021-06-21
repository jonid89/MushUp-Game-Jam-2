using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float speed = 2f;
    [SerializeField] private float _scaleStart = 3f;
    [SerializeField] private float _scaleLimit = 0.5f;
    [SerializeField] private float _shrinkRate = 0.1f;
    [SerializeField] private float _projectileHealth = 2f;
    private float _scale;
    

    private Transform _playerTransform;
    private Transform _enemyTransform;
   
    
    private void Awake()
    {
        _playerTransform = GameObject.Find("Player").transform;
    }

    void Start()
    {
        _enemyTransform = this.transform;
        
        _scale = _scaleStart;
        transform.localScale = new Vector3(_scale, _scale, 1f);
    }


    private void FixedUpdate()
    {
        //direction
        transform.right = _playerTransform.position - _enemyTransform.position;
        
        //movement
        transform.position = Vector3.MoveTowards(_enemyTransform.position, _playerTransform.position, speed * Time.fixedDeltaTime);

        //scaling down
        _scale -= _shrinkRate * Time.fixedDeltaTime;
        if (_scale > _scaleLimit) transform.localScale = new Vector3(_scale, _scale, 1f);
        else Destroy(this.gameObject);


    }

    public void HealthUp()
    {
        _scale += _projectileHealth;
    }


}
