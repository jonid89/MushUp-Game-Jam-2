using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private int _waveNumber = 1;
    [SerializeField] private int _enemiesPerWave = 5;
    [SerializeField] private float _enemySpawnRate = 2f;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _waveAnnouncer;

    private int _enemiesToSpawn;
    private Vector2 _spawnPosition;
    private bool _allSpawned = false;
    private GameObject _enemyFound;

    void Start()
    {
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
        _enemiesToSpawn = _enemiesPerWave * _waveNumber;

        for (int i = 1; i <= _enemiesToSpawn; i++) {
            
            yield return new WaitForSeconds(_enemySpawnRate);

            _spawnPosition = new Vector2(Random.Range(-2, 5), Random.Range(0, 8));

            Instantiate(_enemyPrefab, _spawnPosition, Quaternion.identity);

            if (i == _enemiesToSpawn) _allSpawned = true;
        }

    }

    private void WaveCompleted()
    {
        _waveNumber++;
        _waveAnnouncer.gameObject.SetActive(true);
        StartCoroutine(SpawnEnemies());
    }


}
