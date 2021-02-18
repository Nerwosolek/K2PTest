using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _speed;

    private float _initialY;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) Debug.LogWarning("Attach Rigidbody to Enemy.");
        _initialY = transform.position.y;
    }
    void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 moveDir = new Vector3(_playerTransform.position.x - transform.position.x, _initialY - transform.position.y, _playerTransform.position.z - transform.position.z).normalized;
        if ((transform.position - _playerTransform.position).sqrMagnitude > 1f)
            _rigidbody.AddForce((moveDir * _speed - _rigidbody.velocity), ForceMode.Impulse);
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }

    public void SetTarget(Transform target)
    {
        _playerTransform = target;
    }


}
