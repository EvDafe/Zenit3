using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _cloudPrefabs;

    private void Awake()
    {
        StartCoroutine(SpawningRoutine());
    }

    private IEnumerator SpawningRoutine()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 0.75f));
        {
            if(!PauseSetHandler.Instance.IsPaused && !GameFinalHandler.Instance.IsGameEnd)
            {
                Vector2 playerPos = GameObject.Find("Rocket").transform.position;
                GameObject cloud = Instantiate(_cloudPrefabs[Random.Range(0, _cloudPrefabs.Length)], new Vector2(playerPos.x + Random.Range(-3.5f, 3.5f), playerPos.y + 10f), Quaternion.identity);
                cloud.transform.localScale = Vector2.zero;
                cloud.transform.DOScale(Random.Range(0.25f, 0.5f), 0.5f);
                SpriteRenderer cloudRenderer = cloud.GetComponent<SpriteRenderer>();
                cloudRenderer.color = Color.clear;
                cloudRenderer.DOColor(Color.white, 0.5f);
            }
            StartCoroutine(SpawningRoutine());
        }
    }
}
