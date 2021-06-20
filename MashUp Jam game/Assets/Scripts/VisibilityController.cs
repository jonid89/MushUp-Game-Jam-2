using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    private Vector3 _playerTransform;
    private Sprite _sprite;
    void Start()
    {
        _playerTransform = GameObject.Find("Player").transform.position;
        if(!TryGetComponent(out _sprite))
            Debug.LogError("Couldn't find");
    }

}
