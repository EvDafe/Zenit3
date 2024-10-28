using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaneUpgrader : MonoBehaviour
{
    public int PlaneIndex;

    public int[] Prices;

    [SerializeField] private Button _upgradeControlButton, _scoreSpeedButton, _planeSpeedButton;

    [SerializeField] private TMP_Text _controlLevel, _scoreSpeedLevel, _planeSpeedLevel;

    public void UpgradeControl()
    {
        int currentLevel = PlayerPrefs.GetInt($"{PlaneIndex}-ControlLevel", 1);
        int max = 5;
        int price = Prices[0];
        if (currentLevel < max)
        {
            if (CoinsHandler.Instance.GetMoney() - price >= 0)
            {
                currentLevel++;
                PlayerPrefs.SetInt($"{PlaneIndex}-ControlLevel", currentLevel);
                CoinsHandler.Instance.AddMoney(-price);
            }
        }
    }

    public void UpgradeScoreSpeed()
    {
        int currentLevel = PlayerPrefs.GetInt($"{PlaneIndex}-ScoreSpeedLevel", 1);
        int max = 5;
        int price = Prices[1];
        if (currentLevel < max)
        {
            if (CoinsHandler.Instance.GetMoney() - price >= 0)
            {
                currentLevel++;
                PlayerPrefs.SetInt($"{PlaneIndex}-ScoreSpeedLevel", currentLevel);
                CoinsHandler.Instance.AddMoney(-price);
            }
        }
    }

    public void UpgradePlaneSpeed()
    {
        int currentLevel = PlayerPrefs.GetInt($"{PlaneIndex}-PlaneSpeedLevel", 1);
        int max = 5;
        int price = Prices[2];
        if (currentLevel < max)
        {
            if (CoinsHandler.Instance.GetMoney() - price >= 0)
            {
                currentLevel++;
                PlayerPrefs.SetInt($"{PlaneIndex}-PlaneSpeedLevel", currentLevel);
                CoinsHandler.Instance.AddMoney(-price);
            }
        }
    }

    private void Update()
    {
        UpdateControlVisuals();
        UpdateScoreSpeedVisuals();
        UpdatePlaneSpeedVisuals();
    }

    private void UpdateControlVisuals()
    {
        int currentLevel = PlayerPrefs.GetInt($"{PlaneIndex}-ControlLevel", 1);
        _upgradeControlButton.interactable = currentLevel < 5;
        _controlLevel.text = $"{currentLevel}/5";
    }

    private void UpdateScoreSpeedVisuals()
    {
        int currentLevel = PlayerPrefs.GetInt($"{PlaneIndex}-ScoreSpeedLevel", 1);
        _scoreSpeedButton.interactable = currentLevel < 5;
        _scoreSpeedLevel.text = $"{currentLevel}/5";
    }

    private void UpdatePlaneSpeedVisuals()
    {
        int currentLevel = PlayerPrefs.GetInt($"{PlaneIndex}-PlaneSpeedLevel", 1);
        _planeSpeedButton.interactable = currentLevel < 5;
        _planeSpeedLevel.text = $"{currentLevel}/5";
    }
}
