using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpriteChanger : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private SpriteRenderer _sprite;

    private void OnEnable()
    {
        _boss.HealthChanged += OnHealthChanged;
    }
    private void OnDisable()
    {
        _boss.HealthChanged -= OnHealthChanged;
    }

    private void FixedUpdate()
    {
        _sprite.color = Color.white;
    }

    private void OnHealthChanged(int health)
    {
        _sprite.color = Color.red;
    }
}
