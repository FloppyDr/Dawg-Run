using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class About : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    private CanvasGroup _aboutGroup;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseButtonClick);      
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);  
    }

    private void Start()
    {
        _aboutGroup = GetComponent<CanvasGroup>();
        HideWindow();
    }

    private void OnCloseButtonClick()
    {
        HideWindow();
    }

   

    private void HideWindow()
    {
        _aboutGroup.alpha = 0;
        _aboutGroup.interactable = false;
        _aboutGroup.blocksRaycasts = false;
    }

    public void ShowWindow()
    {
        _aboutGroup.alpha = 1;
        _aboutGroup.interactable = true;
        _aboutGroup.blocksRaycasts = true;
    }
}
