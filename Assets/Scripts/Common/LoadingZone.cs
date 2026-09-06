using System;
using UnityEngine;

public class LoadingZone : MonoBehaviour
{
    public event Action<Truck> TruckDetected;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Truck truck))
            TruckDetected?.Invoke(truck);
    }
}