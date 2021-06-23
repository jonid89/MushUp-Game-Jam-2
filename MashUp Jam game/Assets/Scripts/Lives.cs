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
        _life3.GetComponent<Animator>().enabled = false;
        _life2.GetComponent<Animator>().enabled = false;
        _life1.GetComponent<Animator>().enabled = false;
    }


    void Update()
    {
        
    }

    public void Damaged()
    {
        _currentLifes--;
        if (_currentLifes == 2) StartCoroutine(LosingLife(_life3));
        if (_currentLifes == 1) StartCoroutine(LosingLife(_life2));
        if (_currentLifes == 0) _life1.SetActive(false);
    }

    IEnumerator LosingLife(GameObject _losingLife)
    {
        _losingLife.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3);
        _losingLife.SetActive(false);
    }


}
