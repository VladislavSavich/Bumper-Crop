using UnityEngine;

public class InputController : MonoBehaviour
{
    private GameInput _gameInput;

    public Vector3 Direction { get; private set; }
    
    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();
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
}