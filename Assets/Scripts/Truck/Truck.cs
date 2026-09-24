using System;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] private TruckMover _mover;
    [SerializeField] private HarvestCounter _counter;

    public event Action<Truck> OnTruckFull;
    public bool IsFull { get; private set; }

    private void Start()
    {
        _mover.MoveToStartPosition();
        IsFull = false;
    }
    
    private void OnEnable()
    {
        _mover.MoveToStartPosition();
        _counter.OnFull += CompleteLoading;
    }

    private void OnDisable()
    {
        _counter.OnFull -= CompleteLoading;
    }

    public void AcceptHarvest()
    {
        if (!IsFull)
            _counter.AddCount();
    }
    
    public void ResetCondition()
    {
        IsFull = false;
        _counter.ResetCounter();
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    
    private void CompleteLoading()
    {
        IsFull = true;
        _mover.MoveAway();
        OnTruckFull?.Invoke(this);
    }
}