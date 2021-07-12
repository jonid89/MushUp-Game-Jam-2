using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private GameObject _player;

    [SerializeField] private float speed = 15f;
  

    void Start()
    {
        if(!TryGetComponent(out _rigidbody2D))
            Debug.LogError($"Couldn't find Rigidbody2D on {gameObject.name}");

        _rigidbody2D.velocity = transform.right * speed;
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            FMODUnity.RuntimeManager.PlayOneShot("event:/shot_player");
            other.GetComponent<ShootingController>().EnableShooting();
            Destroy(gameObject);
        }

        if (other.CompareTag("Enemy"))
        {

            FMODUnity.RuntimeManager.PlayOneShot("event:/enemy_hit");
            other.GetComponent<Enemy>().HealthUp();
            _player = GameObject.Find("Player");
            _player.GetComponent<ShootingController>().EnableShooting();
            Destroy(gameObject);
        }

        if (other.CompareTag("WaveControl"))
        {

            FMODUnity.RuntimeManager.PlayOneShot("event:/shot_player");
            other.GetComponent<WaveSpawner>().SpawnShotDown();
            _player = GameObject.Find("Player");
            _player.GetComponent<ShootingController>().EnableShooting();
            Destroy(gameObject);
        }

    }
}
