using TMPro;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private float _minDistance = 0.1f;

    private Vector3 _prevPosition;

    public LineRenderer Line => _line;

    private void Awake()
    {
        _line.positionCount = 1;
        _prevPosition = transform.position;
    }

    public void StartLine(Vector3 position)
    {
        _line.positionCount = 1;
        _line.SetPosition(0, position);
    }

    public void UpdateLine()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z = 0;

            if(Vector3.Distance(currentPos, _prevPosition) > _minDistance)
            {
                if(_prevPosition == transform.position)
                {
                    _line.SetPosition(0, currentPos);
                }
                else
                {
                    _line.positionCount++;
                    _line.SetPosition(_line.positionCount - 1, currentPos);
                }
                _prevPosition = currentPos;
            }
        }
    }
}
