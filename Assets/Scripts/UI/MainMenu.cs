using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _aboutButton;
    [SerializeField] private TMP_Text _distanceLable;
    [SerializeField] private TMP_Text _coinsLable;
    [SerializeField] private ResetProgress _resetWindow;
    [SerializeField] private About _aboutWindow;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _resetButton.onClick.AddListener(OnResetButtonClick);
        _aboutButton.onClick.AddListener(OnAboutButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _resetButton.onClick.RemoveListener(OnResetButtonClick);
        _aboutButton.onClick.RemoveListener(OnAboutButtonClick);
    }

    private void Awake()
    {
        UpdateProgress();
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 1;
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnResetButtonClick()
    {
        _resetWindow.ShowWindow();
    }

    private void OnAboutButtonClick()
    {
        _aboutWindow.ShowWindow();
    }

    private void UpdateProgress()
    {
        _distanceLable.text = "Лучшая дистанция: " + PlayerPrefs.GetInt("Distance").ToString();
        _coinsLable.text = "Монетки: " + PlayerPrefs.GetInt("Coins").ToString();
    }
}
