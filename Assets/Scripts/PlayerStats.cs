using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PlayerDeathDelegate(object sender, EventArgs eventArgs);
public class PlayerStats : MonoBehaviour
{
    public event PlayerDeathDelegate OnPlayerDeath;
    [SerializeField]
    private float _hitPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitPoints < 0)
        {
            OnPlayerDeath?.Invoke(this, new EventArgs());
        }
    }

    public void TakeDamage(float damage)
    {
        _hitPoints -= damage;
        // update UI;
    }
}
