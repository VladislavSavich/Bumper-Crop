using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _maxsScale;
    [SerializeField] private Vector3 _minScale;
    [SerializeField] private float _growthDuration;
    [SerializeField] private float _pulseDuration;
    [SerializeField] private int _repeats;

    private Vector3 _startScale;
    private Tween _growth;
    private Tween _pulse;
    
    private void OnEnable()
    {
        _startScale = transform.localScale;
        
        _growth = transform.DOScale(_maxsScale, _growthDuration).SetEase(Ease.Linear).OnComplete(StartPulse);
    }
    
    private void OnDisable()
    {
        _growth?.Kill();
        _pulse?.Kill();
        transform.localScale = _startScale;
    }
    
    private void StartPulse()
    {
        _pulse = transform.DOScale(_minScale, _pulseDuration).SetLoops(_repeats, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
