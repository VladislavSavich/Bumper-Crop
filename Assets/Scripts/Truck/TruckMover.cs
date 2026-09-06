using UnityEngine;
using DG.Tweening;

public class TruckMover : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private int _zStartPosition = 37;
    [SerializeField] private float _sloDuration = 1.5f;
    [SerializeField] private float _fastDuration = 0.1f;
    
    private Sequence _currentTween;

    public void MoveToStartPosition()
    {
        _currentTween?.Kill();
        
        _currentTween = DOTween.Sequence()
            .Append(transform.DOLocalMoveZ(_zStartPosition, _sloDuration));
    }

    public void MoveAway()
    {
        _currentTween?.Kill();

        _currentTween  = DOTween.Sequence()
            .Append(transform.DOMove(_firstPoint.position, _fastDuration))
            .Append(transform.DOLocalRotate(new Vector3(0, -90, 0), _fastDuration))
            .Append(transform.DOMove(_secondPoint.position, _sloDuration));
    }
}