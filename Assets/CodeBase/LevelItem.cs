using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.CodeBase
{
    public class LevelItem : MonoBehaviour
    {
        [SerializeField] private Button _buttondfdpop;
        [SerializeField] private TMP_Text _numberTextqerofo;
        [SerializeField] private Image _BGvkbjdl;
        [SerializeField] private Color _unlockedColoradflgk;
        [SerializeField] private Color _lockedColorflflfe;

        public int IDqeqewv;

        public void SetNumberdadagg(int iddqdqll)
        {
            IDqeqewv = iddqdqll;
            _numberTextqerofo.text = IDqeqewv.ToString();
        }

        public void Locksdvgki()
        {
            _buttondfdpop.onClick.RemoveAllListeners();
            _BGvkbjdl.color = _lockedColorflflfe;
        }

        public void Unlockfrgtnh()
        {
            _buttondfdpop.onClick.RemoveAllListeners();
            _BGvkbjdl.color = _unlockedColoradflgk;
            _buttondfdpop.onClick.AddListener(LoadSceneqfgthy);
        }

        private void LoadSceneqfgthy()
        {
            SceneManager.LoadScene(IDqeqewv.ToString());
        }
    }
}
