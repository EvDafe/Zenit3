using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSkinLoader : MonoBehaviour
{
    [SerializeField] private Sprite[] _variations;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = Color.clear;
        _renderer.DOColor(Color.white, 1f);
        _renderer.sprite = _variations[PlaneChooseHandler.PlaneIndex];
    }
}
