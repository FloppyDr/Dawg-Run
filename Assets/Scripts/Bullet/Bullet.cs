using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Boss boss))
        {
            boss.ApplyDamage(_damage);
            Die();
        }
        else if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
            Die();
        }
        else if (collision.TryGetComponent(out Destroier destroier))
        {
            Die();
        }

    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
