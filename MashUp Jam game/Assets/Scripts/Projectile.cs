using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile :  MonoBehaviour
{
    
     Rigidbody2D rigidbody2d;


    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        If (transform.position.magnitude > 100.0F) Destroy(gameObject);
    }
    


    Public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
                
        Destroy(gameObject);
    }

}
