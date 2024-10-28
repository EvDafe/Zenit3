using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeToggleHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _stateText;

    [SerializeField] private Image _indicator;

    [SerializeField] private AudioMixer _mixer;

    public bool IsOn = true;

    public void Toggle()
    {
        IsOn = !IsOn;
        _indicator.DOColor(IsOn ? Color.green : Color.red, 0.5f);
        _stateText.text = IsOn ? "ON" : "OFF";
        _mixer.SetFloat("Volume", IsOn ? 10 : -80);
    }
}
