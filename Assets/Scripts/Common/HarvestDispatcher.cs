using UnityEngine;

public class HarvestDispatcher : MonoBehaviour
{
    [SerializeField] private LoadingZone _firstLoadingZone;
    [SerializeField] private LoadingZone _secondLoadingZone;
    [SerializeField] private HarvestCounter  _globalCounter;
    [SerializeField] private Cutter _cutter;
    [SerializeField] private StorageRegulator _regulator;

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

    private void ReceiveHarvest(Color color)
    {
        if (_activeTruck != null && !_activeTruck.IsFull && color ==  _activeTruck.CurrentColor)
            _activeTruck.AcceptHarvest();
        else if (_waitingTruck != null && !_waitingTruck.IsFull  && color ==  _waitingTruck.CurrentColor)
            _waitingTruck.AcceptHarvest();
        else
            _regulator.DistributeHarvest(color);
        
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