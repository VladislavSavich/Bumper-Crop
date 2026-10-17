using System;
using DG.Tweening;
using UnityEngine;

public class Haystack : MonoBehaviour
{
    [SerializeField] private float _flightDuration = 0.5f;

    private Transform _target;
    private Tween _flight;
    
    public event Action<Haystack> OnArrived;

    public void FlyTo(Transform target)
    {
        _flight =  transform
            .DOMove(target.position, _flightDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => OnArrived?.Invoke(this));
    }
    
    public void Reset()
    {
        _flight?.Kill();
    }
}