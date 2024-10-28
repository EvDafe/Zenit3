using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class AchivementManage : MonoBehaviour
    {
        private CoinsHandler _walletdqkkdk => CoinsHandler.Instance;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }



        private void Update()
        {
            if(PlayerPrefs.GetInt("Achive1",0) == 0 && PlayerPrefs.GetInt("UnlockedLevels", 1) == 2)
            {
                PlayerPrefs.SetInt("Achive1", 1);
                _walletdqkkdk.AddMoney(100);
            }
            if (PlayerPrefs.GetInt("Achive2", 0) == 0 && PlayerPrefs.GetInt("UnlockedLevels", 1) == 4)
            {
                PlayerPrefs.SetInt("Achive2", 1);
                _walletdqkkdk.AddMoney(100);
            }
            if (PlayerPrefs.GetInt("Achive3", 0) == 0 && PlayerPrefs.GetInt("UnlockedLevels", 1) == 6)
            {
                PlayerPrefs.SetInt("Achive3", 1);
                _walletdqkkdk.AddMoney(100);
            }
            if (PlayerPrefs.GetInt("Achive4", 0) == 0 && PlayerPrefs.GetInt("Asteroids", 1) >= 3)
            {
                PlayerPrefs.SetInt("Achive4", 1);
                _walletdqkkdk.AddMoney(100);
            }
            if (PlayerPrefs.GetInt("Achive5", 0) == 0 && (PlayerPrefs.GetInt($"{0}-ScoreSpeedLevel", 1) == 2 || PlayerPrefs.GetInt($"{0}-ControlLevel", 1) == 2 || PlayerPrefs.GetInt($"{0}-PlaneSpeedLevel", 1) == 2))
            {
                PlayerPrefs.SetInt("Achive5", 1);
                _walletdqkkdk.AddMoney(100);
            }
            PlayerPrefs.Save();
        }
    }
}
