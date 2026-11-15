using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private SwipeDetector _swipeDetector;
    
    private GameInput _gameInput;

    public Vector3 Direction { get; private set; }
    
    private void Awake()
    {
        _gameInput = new GameInput();
        
        _swipeDetector.Initialize(
            _gameInput.Gameplay.Touch,
            _gameInput.Gameplay.TouchPosition
        );
    }

    private void OnEnable()
    {
        _gameInput.Enable();
        _swipeDetector.SwipeDetected += ReadMovement;
    }

    private void OnDisable()
    {
        _gameInput.Disable();
        _swipeDetector.SwipeDetected -= ReadMovement;
    }

    private void Update()
    {
        ReadMovement();
    }

    private void ReadMovement()
    {
       var input = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
       
       if (!Mathf.Approximately(Mathf.Abs(input.x), Mathf.Abs(input.y)))
           Direction = new Vector3(input.x, 0, input.y);
       else
           Direction = Vector3.zero;
    }

    private void ReadMovement(Vector2 direction)
    {
        Direction = new Vector3(direction.x, 0, direction.y);
    }
}