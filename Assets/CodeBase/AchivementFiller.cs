using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class AchivementFiller : MonoBehaviour
    {
        [SerializeField] private List<AchivementItem> _itemsdadkop;

        private void OnEnable()
        {
            SetAchivementStatesqeptp();
        }

        private void SetAchivementStatesqeptp()
        {
            _itemsdadkop.ForEach(x => x.Unreachdkgkhl());

            if(PlayerPrefs.GetInt("Achive1", 0) == 1)
            {
                _itemsdadkop[0].Reachdofpgp();
            }
            if (PlayerPrefs.GetInt("Achive2", 0) == 1)
            {
                _itemsdadkop[1].Reachdofpgp();
            }
            if (PlayerPrefs.GetInt("Achive3", 0) == 1)
            {
                _itemsdadkop[2].Reachdofpgp();
            }
            if (PlayerPrefs.GetInt("Achive4", 0) == 1)
            {
                _itemsdadkop[3].Reachdofpgp();
            }
            if (PlayerPrefs.GetInt("Achive5", 0) == 1)
            {
                _itemsdadkop[4].Reachdofpgp();
            }
        }
    }
}
