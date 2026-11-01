using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<Grass> GrassDetected;
    public event Action<Bonus> BonusDetected;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Grass grass))
            GrassDetected?.Invoke(grass);
        
        if(collision.gameObject.TryGetComponent(out Bonus bonus))
            BonusDetected?.Invoke(bonus);
    }
}