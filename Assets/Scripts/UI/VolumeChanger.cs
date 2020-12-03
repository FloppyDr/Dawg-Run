using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
    }

    private void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume",Mathf.Lerp(-80,0,volume));

        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
