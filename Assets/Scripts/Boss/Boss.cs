using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _deathEffect;

    public event UnityAction<int> HealthChanged;   
    public event UnityAction Died;


    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
