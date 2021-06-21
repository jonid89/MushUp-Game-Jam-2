using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] private GameObject _life1;
    [SerializeField] private GameObject _life2;
    [SerializeField] private GameObject _life3;

    private int _currentLifes = 3;

    void Start()
    {
        _currentLifes = 3;
    }


    void Update()
    {
        
    }

    public void Damaged()
    {
        _currentLifes--;
        if (_currentLifes == 2) _life1.SetActive(false);
        if (_currentLifes == 1) _life2.SetActive(false);
        if (_currentLifes == 0) _life3.SetActive(false);

    }

}
