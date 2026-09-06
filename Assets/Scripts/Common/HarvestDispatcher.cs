using UnityEngine;

public class HarvestDispatcher : MonoBehaviour
{
    [SerializeField] private LoadingZone _firstLoadingZone;
    [SerializeField] private LoadingZone _secondLoadingZone;
    [SerializeField] private Cutter  _cutter;
    
    private Truck _firstTruck;
    private Truck _secondTruck;
    
    private void OnEnable()
    {
        _firstLoadingZone.TruckDetected += RegisterTruck;
        _secondLoadingZone.TruckDetected += RegisterTruck;
        _cutter.GrassCuttered  += ReceiveHarvest;
    }

    private void OnDisable()
    {
        _firstLoadingZone.TruckDetected -= RegisterTruck;
        _secondLoadingZone.TruckDetected -= RegisterTruck;
        _cutter.GrassCuttered  -= ReceiveHarvest;
    }

    private void ReceiveHarvest()
    {
        if(_firstTruck == null)
            return;
        
        if (!_firstTruck.IsFull)
        { 
            _firstTruck.AcceptHarvest();
        }
        else
        {
            _firstTruck = _secondTruck;
            _secondTruck  = null;
        }
    }

    private void RegisterTruck(Truck truck)
    {
        if (_firstTruck == null)
            _firstTruck = truck;
        else if (_secondTruck == null)
            _secondTruck = truck;
    }
}