using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PlayerDeathHandler();
public delegate void PlayerDropHP(float percent);
public class PlayerStats : MonoBehaviour, IDamageble
{
    public event PlayerDeathHandler OnPlayerDeath;
    public event PlayerDropHP OnHPDrop;
    [SerializeField]
    private float _maxHitPoints;
    
    private float _hitPoints;

    private void Awake()
    {
        _hitPoints = _maxHitPoints;
    }

    public void TakeDamage(float damage)
    {
        _hitPoints -= damage;
        OnHPDrop?.Invoke(_hitPoints / _maxHitPoints);
        if (_hitPoints <= 0f)
            OnPlayerDeath?.Invoke();
    }
}
