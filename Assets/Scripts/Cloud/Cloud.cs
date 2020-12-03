using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Destroier destroier))
        {
            Die();
        }

    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
