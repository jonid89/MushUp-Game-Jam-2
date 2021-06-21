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
        switch (_currentLifes)
        {
            case 2:
                _life1.SetActive(false);
                break;
            case 1:
                _life2.SetActive(false);
                break;
            case 0:
                _life3.SetActive(false);
                break;
        }
    }

}
