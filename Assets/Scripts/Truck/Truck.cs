using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Truck : MonoBehaviour
{
    [SerializeField] private TruckMover _mover;
    [SerializeField] private HarvestCounter _counter;
    private Renderer  _renderer;
    
    public event Action<Truck> OnTruckFull;
    
    public int HarvestCount => _counter.HarvestCount;
    public int MaxCapacity => _counter.MaxCapacity;
    public Color CurrentColor => _renderer.material.color;
    public bool IsFull { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    
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

    public void AcceptHarvest(int value = 1)
    {
        if (IsFull)
            return;
        
        _counter.AddCount(value);
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