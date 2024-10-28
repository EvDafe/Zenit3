using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase
{
    public class LevelPanelFiller : MonoBehaviour
    {
        [SerializeField] private List<LevelItem> _itemsadakdk;


        private void Start()
        {
            InitializeItemsdfrtgk();
        }

        private void InitializeItemsdfrtgk()
        {
            if(PlayerPrefs.GetInt("UnlockedLevels", 1) > 6 ) {
                PlayerPrefs.SetInt("UnlockedLevels", 6);
                PlayerPrefs.Save();
            }
            _itemsadakdk.ForEach(x => x.Locksdvgki());
            for(int i = 1; i <= _itemsadakdk.Count; i++)
                _itemsadakdk[i-1].SetNumberdadagg(i);
            for (int i = 0; i < PlayerPrefs.GetInt("UnlockedLevels", 1); i++)
                _itemsadakdk[i].Unlockfrgtnh();
        }
    }
}
