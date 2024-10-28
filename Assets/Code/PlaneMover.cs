using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaneMover : MonoBehaviour
{
    [SerializeField] private float _verticalSpeed, _horizontalSpeed;

    [SerializeField] private Joystick _joystick;

    [SerializeField] private TMP_Text[] _scoreText;

    private float _xPosition, _yPosition;

    public float Score = 0;

    private void Awake()
    {
        _verticalSpeed += (0.25f * PlaneChooseHandler.PlaneIndex);
        _horizontalSpeed += (0.25f * PlaneChooseHandler.PlaneIndex);
    }

    private void Update()
    {
        if (!PauseSetHandler.Instance.IsPaused && !GameFinalHandler.Instance.IsGameEnd)
        {
            _yPosition += _verticalSpeed * Time.deltaTime;
            _xPosition += _horizontalSpeed * Time.deltaTime * _joystick.Horizontal;
            _xPosition = Mathf.Clamp(_xPosition, -5f, 5f);
            transform.position = new Vector2(_xPosition, _yPosition);
            transform.rotation = Quaternion.Euler(0, 0, 35 * -_joystick.Horizontal);
            Score += Time.deltaTime;
            if(Score > PlayerPrefs.GetFloat("Score", 0))
            {
                PlayerPrefs.SetFloat("Score", Score);
            }
        }

        for (int i = 0; i < _scoreText.Length; i++)
        {
            _scoreText[i].text = ((int)Score).ToString();
        }
    }
}
