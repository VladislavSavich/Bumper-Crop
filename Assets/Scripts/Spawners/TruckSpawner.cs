using System.Collections;
using UnityEngine;

public class TruckSpawner : Spawner<Truck>
{
    [SerializeField] private Transform _firstPosition;
    [SerializeField] private Transform _secondPosition;
    [SerializeField] private float _truckDelay = 3f;
    
    private Transform _currentPosition;
    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_truckDelay);
        _currentPosition = _firstPosition;
        SpawnTruck();
        SpawnTruck();
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
        SubscribeTruck(newTruck);
        newTruck.transform.position = _currentPosition.position;
        
        _currentPosition = _currentPosition == _firstPosition ? _secondPosition : _firstPosition;
    }

    protected override void ReleaseObject(Truck truck)
    {
        truck.ResetCondition();
        truck.gameObject.SetActive(false);
        Pool.Release(truck);
        UnsubscribeTruck(truck);
    }

    private void ReleaseDelay(Truck truck)
    {
        SpawnTruck();
        StartCoroutine(StartReleaseDelay(truck));
    }
    
    private IEnumerator StartReleaseDelay(Truck truck)
    {
        yield return _delay;
        
        ReleaseObject(truck);
    }
}
