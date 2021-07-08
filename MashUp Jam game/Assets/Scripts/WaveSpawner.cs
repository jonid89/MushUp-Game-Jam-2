using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private int _waveNumber = 1;
    [SerializeField] private int _enemiesPerWave = 5;
    [SerializeField] private float _enemySpawnRate = 3f;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _waveAnnouncer;

    private int _enemiesToSpawn;
    private Vector2 _spawnPosition;
    private bool _allSpawned = false;
    private GameObject _enemyFound;
    private Transform _tr;

    void Start()
    {
        _tr = this.transform;
        StartCoroutine(SpawnEnemies());
    }



    void Update()
    {
        
        if (_allSpawned) _enemyFound = GameObject.Find("Enemy(Clone)");
        if (_allSpawned & _enemyFound == null) { _allSpawned = false; WaveCompleted(); }

    }


    IEnumerator SpawnEnemies()
    {
        //yield return new WaitUntil(() => movement.x > 0);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animator>().enabled = true;

        _enemiesToSpawn = _enemiesPerWave * _waveNumber;

        for (int i = 1; i <= _enemiesToSpawn; i++) {

            _spawnPosition = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            _tr.position = _spawnPosition;

            yield return new WaitForSeconds(_enemySpawnRate);

            Instantiate(_enemyPrefab, _spawnPosition, Quaternion.identity);

            if (i == _enemiesToSpawn) _allSpawned = true;
        }

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Animator>().enabled = false;

    }

    private void WaveCompleted()
    {
        _waveNumber++;
        _waveAnnouncer.gameObject.SetActive(true);
        _waveAnnouncer.GetComponent<WaveAnnouncer>().SetWaveNumber(_waveNumber);
        FMODUnity.RuntimeManager.PlayOneShot("event:/new_wave");
        StartCoroutine(SpawnEnemies());
    }


}
