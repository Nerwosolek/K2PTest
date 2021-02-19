using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponStash : MonoBehaviour
{
    [SerializeField]
    AbstractWeapon[] weapons;
    [SerializeField]
    Transform _spawnPoint;
    AbstractWeapon _currentWeapon;
    [SerializeField]
    PlayerMovement _playerMovement;

    private void Awake()
    {
        _currentWeapon = weapons[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            _currentWeapon.Shoot(_spawnPoint.position, _playerMovement.ShootAtPoint);
        }
        
    }
}
