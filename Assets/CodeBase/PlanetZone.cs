using UnityEngine;

namespace Assets.CodeBase
{
    internal class PlanetZone : MonoBehaviour
    {
        [SerializeField] private LineMovement _movement;
        [SerializeField] private Collider2D _collider;

        private void OnMouseEnter()
        {
            Debug.Log("Enter");
            if (_movement.Hold)
            {
                _collider.isTrigger = true;
                _movement.StopDraw();
            }
        }

        private void Update()
        {
            if(_movement._startMovement) {
                _collider.isTrigger = true;
            }
        }
    }
}
