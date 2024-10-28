using Assets.CodeBase;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlaneTriggerHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _coinsCollected;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private LineMovement _lineMovement;

    public UnityEvent OnCoinCollected;

    public int CoinsCollected = 0;
    public ParticleSystem parasdas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin":
                parasdas.Play();
                CoinsCollected++;
                for (int i = 0; i < _coinsCollected.Length; i++)
                {
                    _coinsCollected[i].text = CoinsCollected.ToString();
                }
                collision.transform.DOScale(0, 0.5f);
                Destroy(collision.gameObject, 0.5f);
                CoinsHandler.Instance.AddMoney(1);
                OnCoinCollected.Invoke();
                
                break;
            case "Cloud":
                _rigidBody.bodyType = RigidbodyType2D.Dynamic;
                _rigidBody.gravityScale = 0;
                _lineMovement.StopMoving();
                break;
            case "Planet":
                _rigidBody.bodyType = RigidbodyType2D.Dynamic;
                _rigidBody.gravityScale = 0;
                _lineMovement.StopMoving();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Cloud":
                GameFinalHandler.Instance.Lose();
                GetComponent<Image>().DOColor(Color.white, 0.75f);
                collision.collider.isTrigger = true;
                PlayerPrefs.SetInt("Asteroids", PlayerPrefs.GetInt("Asteroids", 1) + 1);
                PlayerPrefs.Save();
                break;
            case "Planet":
                GameFinalHandler.Instance.Win();
                GetComponent<Image>().DOColor(Color.white, 0.75f);
                collision.collider.isTrigger = true;
                break;
        }
    }
}
