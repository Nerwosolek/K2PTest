using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyCorrosion : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    // Start is called before the first frame update
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
        if (other.tag == "Player")
        {
            CountDown();
            if (_lastHitTime > _hitInterval)
            {
                _lastHitTime = 0f;
                var ps = other.GetComponent<PlayerStats>();
                if (ps != null) ps.TakeDamage(_damage);
            }
        }
    }

    private void CountDown()
    {
        _lastHitTime += Time.fixedDeltaTime;
    }
}
