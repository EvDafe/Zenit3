using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseSetHandler : MonoBehaviour
{
    [SerializeField] private Image _eventBG;

    [SerializeField] private GameObject _pausePanel;

    private Vector2 _defaultPos;

    public bool IsPaused = false;

    private bool _canChangePauseState = true;

    public static PauseSetHandler Instance;

    private void Awake()
    {
        Instance = this;
        _defaultPos = _pausePanel.GetComponent<RectTransform>().position;
        _eventBG.color = Color.clear;
    }

    public void SetToPause()
    {
        if (!IsPaused)
        {
            _eventBG.DOColor(Color.black, 1f);
            _pausePanel.transform.DOMove(new Vector2(Screen.width / 2, Screen.height / 2), 1f);
            IsPaused = true;

            AudioSource[] sources = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i].enabled = false;
            }
        }
    }

    public void Continue()
    {
        if (IsPaused)
        {
            _pausePanel.transform.DOMove(_defaultPos, 1f);
            _eventBG.DOColor(Color.clear, 1f);
            IsPaused = false;

            AudioSource[] sources = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i].enabled = true;
            }
        }
    }

    private IEnumerator BetweenPauseSetDelay()
    {
        yield return new WaitForSeconds(1f);
        {
            _canChangePauseState = true;
        }
    }
}
