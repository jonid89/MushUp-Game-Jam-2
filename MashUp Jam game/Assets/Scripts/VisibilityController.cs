using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    private Vector3 _playerTransform;
    private Sprite _sprite;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.Find("Player").transform.position;
        if(!TryGetComponent(out _sprite))
            Debug.LogError("Couldn't find");
    }

}
