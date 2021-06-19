using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed = 2f;

    private Transform playerTr;
    

    void Start()
    {
        tr
    }



    void Update()
    {
        transform.LookAt(playerTr);

        transform.position += transform.forward * speed * Time.deltaTime;

    }
}
