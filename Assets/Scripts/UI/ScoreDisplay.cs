using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _distanceDisplay;
    [SerializeField] private TMP_Text _coinsDisplay;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.DistanceChanged += OnDistanceChanged;
        _player.CoinsChanged += OnCoinsChanged;
    }
    private void OnDisable()
    {
        _player.DistanceChanged -= OnDistanceChanged;
        _player.CoinsChanged -= OnCoinsChanged;
    }

    private void OnDistanceChanged(int distance)
    {
        _distanceDisplay.text = distance.ToString();
    }

    private void OnCoinsChanged(int coins)
    {
        _coinsDisplay.text = coins.ToString();
    }
}
