using UnityEngine;
using DG.Tweening;

public class TruckMover : MonoBehaviour
{
    [SerializeField] private int _zStartPosition = 37;
    [SerializeField] private int _zEndPosition = -80;
    [SerializeField] private int _zRotatePosition = 30;
    [SerializeField] private float _sloDuration = 5f;
    [SerializeField] private float _fastDuration = 1f;
    [SerializeField] private float _rotateAngle = -90;
    
    private Vector3 _rotateVector;
    private Sequence _currentTween;

    private void Start()
    {
        _rotateVector = new Vector3(0, _rotateAngle, 0);
    }
    
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
            .Append(transform.DOMoveZ(_zRotatePosition, _fastDuration))
            .Append(transform.DOLocalRotate(_rotateVector, _fastDuration))
            .Append(transform.DOMoveX(_zEndPosition, _sloDuration));
    }
}