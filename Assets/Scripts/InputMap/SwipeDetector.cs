using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] private float SwipeThreshold = 50f;

    private InputAction _touchPress;
    private InputAction _touchPosition;
    private Vector2 _startPosition;
    private Vector2 _endPosition;

    public event Action<Vector2> SwipeDetected;

    public void Initialize(InputAction touchPress, InputAction touchPosition)
    {
        _touchPress = touchPress;
        _touchPosition = touchPosition;
    }

    private void OnEnable()
    {
        if (_touchPress == null)
            return;

        _touchPress.performed += OnTouchStarted;
        _touchPress.canceled += OnTouchEnded;
    }

    private void OnDisable()
    {
        if (_touchPress == null)
            return;

        _touchPress.performed -= OnTouchStarted;
        _touchPress.canceled -= OnTouchEnded;
    }

    private void OnTouchStarted(InputAction.CallbackContext context)
    {
        _startPosition = _touchPosition.ReadValue<Vector2>();
    }

    private void OnTouchEnded(InputAction.CallbackContext context)
    {
        _endPosition = _touchPosition.ReadValue<Vector2>();

        Vector2 swipeDelta = _endPosition - _startPosition;

        if (swipeDelta.magnitude < SwipeThreshold)
            return;

        Vector2 direction;

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            direction = swipeDelta.x > 0 ? Vector2.right : Vector2.left;
        else
            direction = swipeDelta.y > 0 ? Vector2.up : Vector2.down;

        SwipeDetected?.Invoke(direction);
    }
}