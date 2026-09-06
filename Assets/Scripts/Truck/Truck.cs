using System;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] private TruckMover _mover;
    [SerializeField] private HarvestCounter _counter;

    public event Action OnTruckFull;
    public bool IsFull { get; private set; }

    private void Start()
    {
        _mover.MoveToStartPosition();
        IsFull = false;
    }
    
    private void OnEnable()
    {
        _counter.OnFull += CompleteLoading;
    }

    private void OnDisable()
    {
        _counter.OnFull -= CompleteLoading;
    }

    public void AcceptHarvest()
    {
        if (!IsFull)
        {
            _counter.AddCount();
            _counter.AddCount();
            _counter.AddCount();
            _counter.AddCount();
            _counter.AddCount();
        }
    }
    
    public void Leave()
    {
        _mover.MoveAway();
    }
    
    private void CompleteLoading()
    {
        IsFull = true;
        OnTruckFull?.Invoke();
    }
}