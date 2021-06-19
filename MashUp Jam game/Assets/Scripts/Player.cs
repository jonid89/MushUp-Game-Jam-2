using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float force = 100;
    public float moveSpeed = 3f;
    public float turnSpeed = 100f;
    public float shootDelay = 3f;

    public GameObject front;
    public GameObject projectilePrefab;
 
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode right;
    public KeyCode left;
    public KeyCode fire;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lookDir;
    private float shootTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootTimer = shootDelay;
    }
    
    
    void Update()
    {
        lookDir.x = front.transform.position.x - rb.position.x;
        lookDir.y = front.transform.position.y - rb.position.y;

        //rotation
        if (Input.GetKey(right))
        {
            rb.rotation = rb.rotation - Mathf.Sign(movement.y) * turnSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(left))
        {
            rb.rotation = rb.rotation + Mathf.Sign(movement.y) * turnSpeed * Time.deltaTime;
        }
        else
        {
            movement.y = 0;
        }

        //forward-backward
        if (Input.GetKey(forward))
        {
            rb.MovePosition(rb.position + moveSpeed * lookDir * Time.deltaTime);
        }
        else if (Input.GetKey(backward))
        {
            rb.MovePosition(rb.position - moveSpeed * lookDir * Time.deltaTime);
        }
        else
        {
            movement.y = 0;
        }

        //firing delay
        shootTimer -= Time.deltaTime;
        if (Input.GetKeyDown(fire) && shootTimer < 0)
        {
            shootTimer = shootDelay;
            Launch();

        }

    }

    void Launch()
    {
        GameObject projectileObj = Instantiate(projectilePrefab, front.transform.position, transform.rotation);

        Projectile projectile = projectileObj.GetComponent<Projectile>();
        projectile.Launch(lookDir, force);

    }

}
