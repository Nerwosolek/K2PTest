using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PlayerDeathHandler();
public class PlayerStats : MonoBehaviour
{
    public event PlayerDeathHandler OnPlayerDeath;
    [SerializeField]
    private float _hitPoints;

    // Update is called once per frame
    void Update()
    {
        if (_hitPoints < 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        _hitPoints -= damage;
        // update UI;
    }
}
