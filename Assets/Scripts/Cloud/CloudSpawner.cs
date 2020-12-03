using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : ObjectPool
{
    [SerializeField] private GameObject[] _cloudTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private float _elapsedTime = 0f;

    private void Start()
    {
        Initialize(_cloudTemplates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _spawnDelay)
        {
            if (TryGetObject(out GameObject cloud))
            {
                _elapsedTime = 0;

                int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

                SetEnemy(cloud, _spawnPoints[spawnPointIndex]);
            }      
        }
    }

    private void SetEnemy(GameObject cloud, Transform spawnPoint)
    {
        cloud.SetActive(true);
        cloud.transform.position = spawnPoint.position;
    }
}
