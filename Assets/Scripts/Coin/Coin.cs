using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _collectedSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.AddCoin();
            player.PlaySound(_collectedSound);

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
