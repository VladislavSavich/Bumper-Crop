using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<Grass> GrassDetected;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Grass grass))
            GrassDetected?.Invoke(grass);
    }
}