using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrassFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _radius;
    [SerializeField] private int _capacity;
    
    private Collider[] _colliders;
    private int _hits;

    private void Awake()
    {
        _colliders = new Collider[_capacity];
    }
    
    public void CollectGrassPositions(List<Transform> results)
    {
        _hits = Physics.OverlapSphereNonAlloc(transform.position, _radius, _colliders, _layerMask);
        
        for (int i = 0; i < _hits; i++)
            if (_colliders[i].TryGetComponent(out Land land))
                results.Add(land.transform);
    }
}