using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private float _elapsedTime = 0f;

    private void Start()
    {
        Initialize(_enemyTemplates,true);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _spawnDelay)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointIndex]);
            }      
        }
    }

    private void SetEnemy(GameObject enemy, Transform spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint.position;
    }
}
