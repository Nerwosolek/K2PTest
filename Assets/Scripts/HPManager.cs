using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnDeathHandler();
public class HPManager : MonoBehaviour
{
    public event OnDeathHandler OnDeath;
    [SerializeField]
    private float _maxHP;
    private float _currentHP;

    private void Awake()
    {
        _currentHP = _maxHP;
    }
    public void TakeDamage(float dmg)
    {
        _currentHP -= dmg;
        if (_currentHP < 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
