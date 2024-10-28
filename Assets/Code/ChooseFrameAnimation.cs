using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChooseFrameAnimation : MonoBehaviour
{
    [SerializeField] private Image[] _backImages;

    private int _lastIndex = -1;

    public void SelectToAnim(int index)
    {
        if (index != _lastIndex)
        {
            for (int i = 0; i < _backImages.Length; i++)
            {
                _backImages[i].DOColor(Color.clear, 0.5f);
            }

            _backImages[index].DOColor(Color.white, 0.5f);
            _lastIndex = index;
        }
    }
}
