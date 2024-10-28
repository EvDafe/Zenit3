using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Player
{
    public class AchivementItem : MonoBehaviour
    {
        [SerializeField] private Image BGdkalfo;
        [SerializeField] private Color _reachedColoreoqpzl;
        [SerializeField] private Color _unreachedColordkfkgk;

        public void Reachdofpgp()
        {
            BGdkalfo.color = _reachedColoreoqpzl;
        }

        public void Unreachdkgkhl()
        {
            BGdkalfo.color = _unreachedColordkfkgk;
        }
    }
}
