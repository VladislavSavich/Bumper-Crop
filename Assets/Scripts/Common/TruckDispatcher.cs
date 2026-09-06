using System.Collections.Generic;
using UnityEngine;

public class TruckDispatcher : MonoBehaviour
{
    [SerializeField] private List<Truck> _trucks;
    
    private Truck _firstCurrentTruck;
    private Truck _secondCurrentTruck; 
    private Coroutine _harvestCoroutine;
    private Queue<Truck> _truckQueue;
    
    private void Start()
    {
        _truckQueue = new Queue<Truck>(_trucks);
        
        SetNextTruck();
    }

    private void OnEnable()
    {
        foreach (var truck in _trucks)
            truck.OnTruckFull += ChangeTruck;
    }

    private void OnDisable()
    {
        foreach (var truck in _trucks)
            truck.OnTruckFull -= ChangeTruck;
    }

    private void ChangeTruck()
    {
        _firstCurrentTruck.Leave();
            
        _firstCurrentTruck = null;
            
        _firstCurrentTruck = _secondCurrentTruck;

        _secondCurrentTruck = null;
            
        SetNextTruck();
    }

    private void SetNextTruck()
    {
        if (_truckQueue.Count <= 0) 
            return;

        if (_firstCurrentTruck == null)
        {
            _firstCurrentTruck = _truckQueue.Dequeue();
            _firstCurrentTruck.gameObject.SetActive(true);
        }
            
        if (_secondCurrentTruck == null)
        {
            _secondCurrentTruck = _truckQueue.Dequeue();
            _secondCurrentTruck.gameObject.SetActive(true);
        }
    }
}