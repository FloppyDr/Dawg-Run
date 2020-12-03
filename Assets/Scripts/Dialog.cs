using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject _bulletSpawner;
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _spawner;
    [SerializeField] private TMP_Text _dialog;
    [SerializeField] private Player _player;
    [SerializeField] private int _targetDistance;
    [TextArea(3,10)]
    [SerializeField] private List<string> _sentences = new List<string>();

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.DistanceChanged += OnDistanceChanged;
        _player.Died += OnDied;
    }
    private void OnDisable()
    {
        _player.DistanceChanged -= OnDistanceChanged;
        _player.Died -= OnDied;
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnDistanceChanged(int distance)
    {
        if (distance==_targetDistance)
        {
            _canvasGroup.alpha = 1;

            StartCoroutine(DoDialog());
        }
    }

    private void OnDied()
    {
        _canvasGroup.alpha = 0;
    }

    private IEnumerator DoDialog()
    {
        var delay = new WaitForSecondsRealtime(5f);

        for (int i = 0; i < _sentences.Count; i++)
        {
            _dialog.text = _sentences[i];
            yield return delay;
        }
        _canvasGroup.alpha = 0;
        _spawner.SetActive(false);
        _boss.SetActive(true);
        _bulletSpawner.SetActive(true);
     
    }

}
