using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class EndScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Boss _boss;
    [SerializeField] private TMP_Text _dialog;
    [TextArea(3, 10)]
    [SerializeField] private List<string> _sentences = new List<string>();

    private float _targetAlpha = 1;
    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _boss.Died += OnDied;
    }
    private void OnDisable()
    {
        _boss.Died -= OnDied;
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnDied()
    {
        StartCoroutine(FadeIn(_targetAlpha));
    }

    private IEnumerator DoDialog()
    {
        var delay = new WaitForSecondsRealtime(6f);

        for (int i = 0; i < _sentences.Count; i++)
        {
            _dialog.text = _sentences[i];
            yield return delay;
        }
        SceneManager.LoadScene(0);
    }

    private IEnumerator FadeIn(float targetVolume)
    {
        while (_canvasGroup.alpha != targetVolume)
        {
            _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, targetVolume, 0.2f * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(DoDialog());
        SaveProgress(_player.Distance, _player.Coins);
    }

    private void SaveProgress(int distance, int coins)
    {
        var savedDistance = PlayerPrefs.GetInt("Distance");
        int totalCoins = PlayerPrefs.GetInt("Coins");
        totalCoins += coins;
        if (savedDistance < distance)
        {
            PlayerPrefs.SetInt("Distance", distance);
        }
        PlayerPrefs.SetInt("Coins", totalCoins);
    }

}
