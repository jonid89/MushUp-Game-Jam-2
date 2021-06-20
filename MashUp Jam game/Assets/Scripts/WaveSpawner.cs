using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private int _waveNumber = 1;
    [SerializeField] private int _enemiesPerWave = 5;
    [SerializeField] private float _enemySpawnRate = 2f;
    [SerializeField] GameObject _enemyPrefab;

    private int _enemiesToSpawn;
    private Vector2 _spawnPosition;

    void Start()
    {
        _enemiesToSpawn = _enemiesPerWave * _waveNumber;

        StartCoroutine(SpawnEnemies());
    }



    void Update()
    {
        
    }


    IEnumerator SpawnEnemies()
    {
        //yield return new WaitUntil(() => movement.x > 0);

        for (int i = 1; i <= _enemiesToSpawn; i++) {
            
            yield return new WaitForSeconds(_enemySpawnRate);

            _spawnPosition = new Vector2(Random.Range(-2, 5), Random.Range(0, 8));

            Instantiate(_enemyPrefab, _spawnPosition, Quaternion.identity);

        }

    }

}
