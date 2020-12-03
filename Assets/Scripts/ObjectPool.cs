using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }      
    }

    protected void Initialize(GameObject[] prefabs,bool enemieSpawner)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int random = Random.Range(0, 100);         
            if (random < 80)
            {
                GameObject spawned = Instantiate(prefabs[0], _container.transform);
                spawned.SetActive(false);
                _pool.Add(spawned);
            }
            else
            {
                GameObject spawned = Instantiate(prefabs[1], _container.transform);
                spawned.SetActive(false);
                _pool.Add(spawned);
            }
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
