using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BladeMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private Vector3 _startPosition;
    private Coroutine _movingCoroutine;
    
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _moveDirection = Vector3.zero;
        _startPosition = transform.position;
        IsMoving = false;

        Reset();
    }

    public void StartMoving(Vector3 direction)
    {
        if (direction == Vector3.zero)
            throw new ArgumentException("Direction can't be ZERO", nameof(direction));
        
        if(IsMoving)
            return;

        _moveDirection = direction * _speed;
        IsMoving = true;

        if (_movingCoroutine == null)
            _movingCoroutine = StartCoroutine(Movement());
    }

    public void StopMoving()
    {
        if(_movingCoroutine != null)
        {
            StopCoroutine(_movingCoroutine);
            _movingCoroutine = null;
        }

        _moveDirection = Vector3.zero;
        IsMoving = false;
    }

    public void Reset()
    {
        _characterController.enabled = false;
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _moveDirection = Vector3.zero;
        _characterController.enabled = true;
    }
    
    private IEnumerator Movement() 
    {
        while (enabled) 
        {
            _characterController.Move(_moveDirection * Time.deltaTime);

            yield return null;
        }
    }
}