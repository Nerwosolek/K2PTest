using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float _dmgRadius;
    [SerializeField]
    private float _maxDmg;
    [SerializeField]
    private float _impact;
    /// <summary>
    /// pinned for safety reasons of the player :)
    /// </summary>
    private bool _pinned;
    private float unpinDelay;

    private void Awake()
    {
        _pinned = true;
        unpinDelay = 0.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_pinned)
        {
            Explode(transform.position, _dmgRadius, _maxDmg);
            Destroy(gameObject);
        }
    }

    private void Explode(Vector3 epicenter, float dmgRadius, float maxDmg)
    {
        Collider[] hits = Physics.OverlapSphere(epicenter, dmgRadius);
        foreach (var hit in hits)
        {
            var damagable = hit.GetComponent<IDamageble>();
            // deal damage proportional to closeness to epicenter
            if (damagable != null) damagable.TakeDamage(maxDmg * (1 - (epicenter - hit.transform.position).magnitude / dmgRadius));
            var rb = hit.GetComponent<Rigidbody>();
            if (rb != null) rb.AddExplosionForce(_impact, epicenter, dmgRadius * 2, 0.5f, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        if (unpinDelay > 0f)
            unpinDelay -= Time.deltaTime;
        else _pinned = false;
    }
}
