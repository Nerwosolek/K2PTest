using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public delegate void EnemyDealsDamageHandler(float damagePoints);
public class EnemyCorrosion : MonoBehaviour
{
    public event EnemyDealsDamageHandler EnemyDealsDamage;

    [SerializeField]
    private float _damage;
   
    [SerializeField]
    private float _hitInterval;
    [SerializeField]
    Collider _effectAreaCollider;
    private float _lastHitTime = 0f;

    private void Awake()
    {
        _lastHitTime = _hitInterval;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CountDown();
            if (_lastHitTime > _hitInterval)
            {
                _lastHitTime = 0f;
                EnemyDealsDamage?.Invoke(_damage);
            }
        }
    }

    private void CountDown()
    {
        _lastHitTime += Time.fixedDeltaTime;
    }
}
