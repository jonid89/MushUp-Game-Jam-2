using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        if(!TryGetComponent(out _rigidbody2D))
            Debug.LogError($"Couldn't find Rigidbody2D on {gameObject.name}");

        _rigidbody2D.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy _enemy = other.collider.GetComponent<Enemy>();
        if (_enemy != null)
        {
            _enemy.HealthUp();
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
