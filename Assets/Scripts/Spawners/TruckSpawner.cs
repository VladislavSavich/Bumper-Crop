using System.Collections;
using UnityEngine;

public class TruckSpawner : Spawner<Truck>
{
    [SerializeField] private ColorChanger  _colorChanger;
    [SerializeField] private Transform _firstPosition;
    [SerializeField] private Transform _secondPosition;
    [SerializeField] private LoadingZone _firstZone;
    [SerializeField] private LoadingZone _secondZone;
    [SerializeField] private float _truckDelay = 2f;
    
    private WaitForSeconds _delay;
    
    protected override void ReleaseObject(Truck truck)
    {
        truck.ResetCondition();
        truck.gameObject.SetActive(false);
        Pool.Release(truck);
        UnsubscribeTruck(truck);
    }
    
    private void Start()
    {
        _delay = new WaitForSeconds(_truckDelay);
        SpawnTruck();
        Invoke(nameof(SpawnTruck), _truckDelay);
    }

    private void SubscribeTruck(Truck  truck)
    {
        truck.OnTruckFull += ReleaseDelay;
    }

    private void UnsubscribeTruck(Truck truck)
    {
        truck.OnTruckFull -= ReleaseDelay;
    }

    private void SpawnTruck()
    {
        Truck newTruck = Pool.Get();
        _colorChanger.ChangeColor(newTruck.gameObject);
        SubscribeTruck(newTruck);
        
        newTruck.transform.position = _firstZone.IsBusy ? _secondPosition.position : _firstPosition.position;
    }

    private void ReleaseDelay(Truck truck)
    {
        Invoke(nameof(SpawnTruck),  _truckDelay);
        StartCoroutine(HandleTruckRelease(truck));
    }
    
    private IEnumerator HandleTruckRelease(Truck truck)
    {
        yield return _delay;
        
        ReleaseObject(truck);
    }
}