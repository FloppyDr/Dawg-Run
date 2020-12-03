using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _deathEffect;

    private int _maxHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            Die();
        }
        else if (collision.TryGetComponent(out Destroier destroier))
        {
            Die();
        }
    }

    private void Start()
    {
        _maxHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
       // HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(_deathEffect,transform.position,Quaternion.identity);
        gameObject.SetActive(false);
        _health = _maxHealth;
    }
}
