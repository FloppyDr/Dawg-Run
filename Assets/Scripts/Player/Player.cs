using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private AudioSource _audioSource;

    private int _distance;
    private int _coinsCount;

    public int Distance => _distance;
    public int Coins => _coinsCount;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> DistanceChanged;
    public event UnityAction<int> CoinsChanged;
    public event UnityAction Died;


    private void Start()
    {
        HealthChanged?.Invoke(_health);
        CoinsChanged?.Invoke(_coinsCount);
    }

    private void FixedUpdate()
    {
        _distance++;
        DistanceChanged?.Invoke(_distance);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health<=0)
        {
            Die();
        }
    }

    public void AddCoin()
    {
        _coinsCount++;
        CoinsChanged?.Invoke(_coinsCount);

    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
