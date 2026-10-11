using System;
using UnityEngine;

public class LoadingZone : MonoBehaviour
{
    public event Action<Truck> TruckDetected;

    public bool IsBusy { get; private set; }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Truck truck))
        {
            TruckDetected?.Invoke(truck);
            IsBusy = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Truck _))
        {
            IsBusy = false;
        }
    }
}