using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class ResetProgress : MonoBehaviour
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _yesButton.onClick.AddListener(OnYesButtonClick);
        _noButton.onClick.AddListener(OnNoButtonClick);
    }

    private void OnDisable()
    {
        _yesButton.onClick.RemoveListener(OnYesButtonClick);
        _noButton.onClick.RemoveListener(OnNoButtonClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        HideWindow();
    }

    private void OnYesButtonClick()
    {
        PlayerPrefs.DeleteKey("Distance");
        PlayerPrefs.DeleteKey("Coins");
        SceneManager.LoadScene(0);
    }

    private void OnNoButtonClick()
    {
        HideWindow();
    }

    private void HideWindow()
    {
        _gameOverGroup.alpha = 0;
        _gameOverGroup.interactable = false;
        _gameOverGroup.blocksRaycasts = false;
    }

    public void ShowWindow()
    {
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;
        _gameOverGroup.blocksRaycasts = true;
    }
}


    
