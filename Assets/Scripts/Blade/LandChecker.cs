using UnityEngine;

public class LandChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _rayDistance = 5f;
    [SerializeField] private float _interpolateValue = 0.5f;
    
    private Vector3 _currentDirection;

    public bool IsLand(Vector3 direction) 
    {
        if (direction == Vector3.zero)
            return false;
        
        var rayDirection = new Vector3(direction.x, 0, direction.z).normalized;
        var angledDirection = Vector3.Lerp(Vector3.down, rayDirection, _interpolateValue).normalized;
        
        return Physics.Raycast(transform.position, angledDirection, out var hit, _rayDistance, _layerMask) && hit.collider.TryGetComponent<Land>(out _);
    }
}