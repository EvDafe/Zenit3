using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MenuPanelChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;

    private int _currentPageIndex = 0;

    public int CurrentPageIndex { get => _currentPageIndex; }

    [SerializeField] private Button _nextButton, _previousButton;

    public UnityEvent OnAllPagesCompleted;

    private void Awake()
    {
        UpdatePages();
    }

    private void Update()
    {
        if (_nextButton != null) _nextButton.interactable = _currentPageIndex < _panels.Length - 1;
        if (_previousButton != null) _previousButton.interactable = _currentPageIndex > 0;
    }

    public void NextPage()
    {
        if (_currentPageIndex < _panels.Length - 1)
        {
            _currentPageIndex++;
            UpdatePages();
        }
        else
        {
            OnAllPagesCompleted.Invoke();
        }
    }

    public void PreviousPage()
    {
        if (_currentPageIndex > 0)
        {
            _currentPageIndex--;
            UpdatePages();
        }
    }

    public void UpdatePages()
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            _panels[i].SetActive(false);
        }
        _panels[_currentPageIndex].SetActive(true);
    }

    public void TurnPage(int index)
    {
        _currentPageIndex = index;
        UpdatePages();
    }
}
