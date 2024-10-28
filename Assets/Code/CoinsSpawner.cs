using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    private void Awake()
    {
        StartCoroutine(SpawningRoutine());
    }

    private IEnumerator SpawningRoutine()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        {
            if (!PauseSetHandler.Instance.IsPaused && !GameFinalHandler.Instance.IsGameEnd)
            {
                Vector2 playerPos = GameObject.Find("Rocket").transform.position;
                GameObject coin = Instantiate(_coinPrefab, new Vector2(playerPos.x + Random.Range(-2f, 2f), playerPos.y + 8f), Quaternion.identity);
                coin.transform.localScale = Vector2.zero;
                coin.transform.DOScale(0.05f, 0.5f);
            }
            StartCoroutine(SpawningRoutine());
        }
    }
}
