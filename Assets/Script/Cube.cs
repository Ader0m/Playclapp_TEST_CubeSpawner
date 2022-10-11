using System;
using UnityEngine;

public class Cube : MonoBehaviour, ISpawnedObj
{
    private Rigidbody _rb;
    private Vector3 _lastPosition;
    private float _speed = 5;
    private float _distance = 20;
    private float _currentDistance;

    #region Get/Set

    public void SetDistance(float distance)
    {
        _distance = distance;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    #endregion  

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _currentDistance = 0;
        _lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        MoveLogick();
        SolveDistanceTraveled();
    }

    void MoveLogick()
    {
        _rb.velocity = transform.forward * _speed;
    }

    void SolveDistanceTraveled()
    {
        if (_lastPosition != transform.position)
        {
            _currentDistance += Math.Abs(transform.position.magnitude - _lastPosition.magnitude);
            _lastPosition = transform.position;
            if (_currentDistance >= _distance)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
