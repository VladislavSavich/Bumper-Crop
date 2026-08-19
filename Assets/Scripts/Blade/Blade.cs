using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private BladeMover _mover;
    [SerializeField] private LandChecker _landChecker;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Cutter _cutter;

    private Vector3 _currentDirection;

    private void Start()
    {
        _currentDirection = Vector3.zero;
    }

    private void OnEnable()
    {
        _collisionHandler.GrassDetected += _cutter.CutGrass;
    }

    private void OnDisable()
    {
        _collisionHandler.GrassDetected -= _cutter.CutGrass;
    }

    private void Update()
    {
        if (_inputController.Direction != Vector3.zero && !_mover.IsMoving) 
        {
            _currentDirection = _inputController.Direction;

            if (_landChecker.IsLand(_currentDirection)) 
            {
                _mover.StartMoving(_currentDirection);
            }
        }

        if (_landChecker.IsLand(_currentDirection)) 
            return;
        
        _mover.StopMoving();
        _currentDirection = Vector3.zero;
    }
}