using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    private int _side = 1;

    private void Awake()
    {
        //Destroy(gameObject, 8);
        //_side = Random.Range(1, 10) > 5 ? 1 : -1;
    }

    private void Update()
    {
        if (!PauseSetHandler.Instance.IsPaused)
        {
            //transform.Translate(_side * Time.deltaTime * Vector2.right);
        }
    }
}
