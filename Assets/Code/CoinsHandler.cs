using TMPro;
using UnityEngine;

public class CoinsHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _moneyTexts;

    public static CoinsHandler Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        int money = PlayerPrefs.GetInt("Money", 0);
        for (int i = 0; i < _moneyTexts.Length; i++)
        {
            if (_moneyTexts[i] != null)
            {
                _moneyTexts[i].text = money.ToString();
            }
        }
    }

    public void AddMoney(int valueToAdd)
    {
        int money = PlayerPrefs.GetInt("Money", 0);
        money += valueToAdd;
        PlayerPrefs.SetInt("Money", money);
    }

    public void SetMoney(int targetValue)
    {
        int money = PlayerPrefs.GetInt("Money", 0);
        money = targetValue;
        PlayerPrefs.SetInt("Money", money);
    }

    public int GetMoney() => PlayerPrefs.GetInt("Money", 0);
}
