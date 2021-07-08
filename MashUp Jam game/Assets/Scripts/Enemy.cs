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
    private bool _sideMovement = false;
    private float _sideMoveTimer;
    private float _timeToSideMove = 1f;
    private int _randomSide = 1;



    private void Awake()
    {
        _playerTransform = GameObject.Find("Player").transform;
    }

    void Start()
    {
        _enemyTransform = this.transform;
        
        _scale = _scaleStart;
        transform.localScale = new Vector3(_scale, _scale, 1f);

        _sideMovement = false;
        _sideMoveTimer = _timeToSideMove;

    }


    private void FixedUpdate()
    {
        //direction
        transform.right = _playerTransform.position - _enemyTransform.position;
        
        //movement
        transform.position = Vector3.MoveTowards(_enemyTransform.position, _playerTransform.position, speed * Time.fixedDeltaTime);


        //side movement
        _sideMoveTimer -= Time.fixedDeltaTime;
        if (_sideMoveTimer < 0)
        {
            _sideMoveTimer = _timeToSideMove;
            _sideMovement = false;
            if (Random.Range(1, 3) == 1) _sideMovement = true;
            _randomSide = Random.Range(-1, 2);
        }
        if (_sideMovement == true)
        {
            transform.position += transform.up * _randomSide * speed * Time.fixedDeltaTime;
        }


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
