using UnityEngine;

namespace Assets.CodeBase
{
    public class LineMovement : MonoBehaviour
    {
        [SerializeField] private DrawLine _line;
        [SerializeField] private float _speed;

        public bool Hold;

        private Vector3[] _positions;
        public bool _startMovement;
        private int _moveIndex = 0;
        private bool _canMove = true;

        private void OnMouseDown()
        {
            if(_canMove)
            {
                Hold = true;
                _line.StartLine(transform.position);
            }
        }

        private void OnMouseDrag()
        {
            if (_canMove)
                _line.UpdateLine();
        }

        private void OnMouseUp()
        {
            if (_canMove == false)
                return;
            _positions = new Vector3[_line.Line.positionCount];
            _line.Line.GetPositions(_positions);
            _startMovement = true;
            _moveIndex = 0;
            _canMove = false;
            Hold = false;
        }
        
        public void StopDraw()
        {
            OnMouseUp();
        }

        public void StopMoving()
        {
            _canMove = false;
            _startMovement = false;
        }

        private void Update()
        {
            if(_startMovement)
            {
                transform.position = Vector2.MoveTowards(transform.position, _positions[_moveIndex], _speed);

                var distance = Vector2.Distance(_positions[_moveIndex], transform.position);

                Vector2 direction = (Vector2)_positions[_moveIndex] - (Vector2)transform.position;
                float angle = Mathf.Atan2(direction.normalized.y, direction.normalized.x);
                Debug.Log(angle);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90), 0.5f);
                if (distance <= 0.05f)
                    _moveIndex++;

                if (_moveIndex >= _positions.Length)
                    _startMovement = false;
            }
        }
    }
}
