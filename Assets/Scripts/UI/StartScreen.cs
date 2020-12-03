using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class StartScreen : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private float _targetAlpha = 0;

    private void Awake()
    {
        Time.timeScale = 0;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Time.timeScale = 1;
            StartCoroutine(FadeOut(_targetAlpha));
        }     
    }
   
    private IEnumerator FadeOut(float targetVolume)
    {
        while (_canvasGroup.alpha != targetVolume)
        {
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, targetVolume, 0.1f*Time.deltaTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
