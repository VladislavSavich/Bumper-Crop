using UnityEngine;

public class HarvestDispatcher : MonoBehaviour
{
    [SerializeField] private LoadingZone _firstLoadingZone;
    [SerializeField] private LoadingZone _secondLoadingZone;
    [SerializeField] private Storage _groundStorage;
    [SerializeField] private HarvestCounter  _globalCounter;
    [SerializeField] private Cutter _cutter;
    
    private Truck _activeTruck;
    private Truck _waitingTruck;

    private void OnEnable()
    {
        _firstLoadingZone.TruckDetected += RegisterTruck;
        _secondLoadingZone.TruckDetected += RegisterTruck;
        _cutter.GrassCuttered += ReceiveHarvest;
    }

    private void OnDisable()
    {
        _firstLoadingZone.TruckDetected -= RegisterTruck;
        _secondLoadingZone.TruckDetected -= RegisterTruck;
        _cutter.GrassCuttered -= ReceiveHarvest;
    }

    private void ReceiveHarvest()
    {
        if (_activeTruck != null && !_activeTruck.IsFull)
            _activeTruck.AcceptHarvest();
        else
            _groundStorage.AddHarvest();
        
        _globalCounter.AddCount();
    }
    
    private void RegisterTruck(Truck truck)
    {
        truck.OnTruckFull += HandleTruckFull;

        if (_activeTruck == null)
            _activeTruck = truck;
        else if (_waitingTruck == null)
            _waitingTruck = truck;
    }
    
    private void HandleTruckFull(Truck truck)
    {
        truck.OnTruckFull -= HandleTruckFull;
        
        if (truck == _activeTruck)
        {
            _activeTruck = null;
            
            if (_waitingTruck != null)
            {
                _activeTruck = _waitingTruck;
                _waitingTruck = null;
            }
        }
        else if (truck == _waitingTruck)
        {
            _waitingTruck = null;
        }
    }
}