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

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) Debug.LogWarning("Attach Rigidbody to Enemy.");
    }
    void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        transform.LookAt(_playerTransform.position);
        //_rigidbody.MovePosition(_rigidbody.position + transform.forward * _speed * Time.deltaTime);
        _rigidbody.AddForce(transform.forward * _speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    public void SetTarget(Transform target)
    {
        _playerTransform = target;
    }


}
