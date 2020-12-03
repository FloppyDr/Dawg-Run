using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : ObjectPool
{
    [SerializeField] private GameObject _bulletPrefub;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDelay;

    private float _elapsedTime = 0f;

    private void Start()
    {
        Initialize(_bulletPrefub);
    }

    private void Update()
    {

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _spawnDelay)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (TryGetObject(out GameObject bullet))
                {
                    _elapsedTime = 0;
                    SetBullet(bullet, _spawnPoint);
                }
            }
        }
    }

    private void SetBullet(GameObject bullet, Transform spawnPoint)
    {
        bullet.SetActive(true);
        bullet.transform.position = spawnPoint.position;
    }
}
