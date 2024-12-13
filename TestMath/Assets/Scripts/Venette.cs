using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Venette : MonoBehaviour
{
    
    [SerializeField] private Transform _target;
    [SerializeField] private float _timeStep = 0.02f;
    [SerializeField] private float _damping = 0.99f;
    [SerializeField] private float _stopThreshold = 0.01f;
    [SerializeField] private float _velocityThreshold = 0.01f;

    private Vector3 _previousPosition;
    private Vector3 _currentPosition;

    void Start()
    {
        _currentPosition = transform.position;
        _previousPosition = _currentPosition;
    }

    void Update()
    {
        Vector3 acceleration = (_target.position - _currentPosition).normalized;
        Vector3 newPosition = _currentPosition + (_currentPosition - _previousPosition) * _damping + acceleration * _timeStep * _timeStep;

        // Check if the object is close enough to the target and the velocity is minimal
        if (Vector3.Distance(newPosition, _target.position) < _stopThreshold && Vector3.Distance(newPosition, _currentPosition) < _velocityThreshold)
        {
            newPosition = _target.position;
        }

        _previousPosition = _currentPosition;
        _currentPosition = newPosition;

        transform.position = _currentPosition;
    }
}
