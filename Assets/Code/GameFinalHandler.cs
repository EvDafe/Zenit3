using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameFinalHandler : MonoBehaviour
{
    public bool IsGameWin, IsGameLose, IsGameEnd;

    public UnityEvent OnGameWin, OnGameLose;

    public static GameFinalHandler Instance;

    private GameObject _transitionPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        if (!IsGameEnd)
        {
            AudioSource[] sources = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i].enabled = false;
            }
            IsGameEnd = true;
            IsGameWin = true;
            StartCoroutine(GameEndDelay(true));
            CoinsHandler.Instance.AddMoney(10);
            if(PlayerPrefs.GetInt("UnlockedLevels", 1) == int.Parse(SceneManager.GetActiveScene().name))
            {
                PlayerPrefs.SetInt("UnlockedLevels", PlayerPrefs.GetInt("UnlockedLevels",1) + 1);
                PlayerPrefs.Save();
            }
        }
    }

    public void Lose()
    {
        if (!IsGameEnd)
        {
            AudioSource[] sources = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i].enabled = false;
            }
            IsGameEnd = true;
            IsGameLose = true;
            StartCoroutine(GameEndDelay(false));
        }
    }

    public void ForceLose()
    {
        if (!IsGameEnd)
        {
            AudioSource[] sources = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < sources.Length; i++)
            {
                sources[i].enabled = false;
            }

            GameObject.Find("Audio Source").GetComponent<AudioSource>().enabled = true;
            IsGameEnd = true;
            IsGameLose = true;
            StartCoroutine(GameEndDelay(false));
        }
    }

    private IEnumerator GameEndDelay(bool isWin)
    {
        _transitionPanel = Instantiate(Resources.Load("TransitionScreen") as GameObject);
        _transitionPanel.GetComponentInChildren<Image>().DOColor(Color.black, 1f);

        yield return new WaitForSeconds(1f);
        {
            if (isWin)
            {
                OnGameWin.Invoke();
            }
            else
            {
                OnGameLose.Invoke();
            }

            _transitionPanel.GetComponentInChildren<Image>().DOColor(Color.clear, 1f);
        }
    }
}
