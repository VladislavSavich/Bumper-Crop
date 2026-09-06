using System;
using UnityEngine;

public class HarvestCounter : MonoBehaviour
{
    [SerializeField] private int _maxCapacity = 27;
    
    private int _minValue = 0;
    private int _count;

    public event Action<int> CountChanged;
    public event Action OnFull;

    public int HarvestCount => _count;
    public bool IsFull => _count >= _maxCapacity;
    
    private void Start()
    {
        ResetCounter();
    }
    
    public void AddCount()
    {
        _count++;
        CountChanged?.Invoke(HarvestCount);
        
        if(IsFull)
            OnFull?.Invoke();
    }
    
    private void ResetCounter()
    {
        _count = _minValue;
        CountChanged?.Invoke(HarvestCount);
    }
}