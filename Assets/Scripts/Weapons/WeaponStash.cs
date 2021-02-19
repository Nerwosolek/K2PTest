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
    private int _weapInd;

    private void Awake()
    {
        _weapInd = 0;
        _currentWeapon = weapons[_weapInd];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
        {
            _currentWeapon.Shoot(_spawnPoint.position, _playerMovement.ShootAtPoint);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentWeapon = weapons[(++_weapInd) % weapons.Length];
        }
    }
}
