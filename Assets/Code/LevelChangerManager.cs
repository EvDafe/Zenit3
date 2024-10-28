using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LevelChangerManager : MonoBehaviour
{
    private GameObject _transitionScreenPrefab, _transitionScreenInstance;

    private Image _transScreenImage;

    [SerializeField] private TMP_Text _score;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        _transitionScreenPrefab = Resources.Load("TransitionScreen") as GameObject;
        _transitionScreenInstance = Instantiate(_transitionScreenPrefab);
        _transScreenImage = _transitionScreenInstance.GetComponentInChildren<Image>();
        _transScreenImage.color = Color.black;
        _transScreenImage.DOColor(Color.clear, 1f);
    }

    private void Update()
    {
        if(_score != null)
        {
            _score.text = ((int)PlayerPrefs.GetFloat("Score", 0)).ToString();
        }
    }

    public void LoadScene(int index) => LoadSceneAnimated(index);

    private bool _isLoading = false;

    private void LoadSceneAnimated(int index)
    {
        if (!_isLoading)
        {
            _transScreenImage.DOColor(Color.black, 1f);
            StartCoroutine(LoadDelay(index));
            _isLoading = true;
        }
    }

    private IEnumerator LoadDelay(int index)
    {
        yield return new WaitForSeconds(1f);
        {
            SceneManager.LoadScene(index);
        }
    }

    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().name != "7")
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            LoadScene(Random.Range(1,7));
    }

    public void Reload() => LoadScene(SceneManager.GetActiveScene().buildIndex);
}
