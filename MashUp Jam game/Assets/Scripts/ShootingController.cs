using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Transform projectileOriginTransform;
    [SerializeField] private GameObject bullet;
    [SerializeField] Joystick _joystick;
    
    private bool _canShoot = true;
    private Vector2 _directionInput;
    private Vector2 _previousInput;
    private Camera _mainCamera;
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //var aimDirection = (mousePosition - transform.position).normalized;
    
        _directionInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        if (_directionInput == new Vector2(0, 0) & _directionInput != _previousInput) {
            var aimDirection = _previousInput.normalized;
            var angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
            Shoot();
        }

        _previousInput = _directionInput;
    }

    public void Shoot()
    {
        if (!_canShoot) return;
        Instantiate(bullet, projectileOriginTransform.position, projectileOriginTransform.rotation);
        FMODUnity.RuntimeManager.PlayOneShot("event:/shot");
        _canShoot = false;
    }

    public void EnableShooting() => _canShoot = true;
}
