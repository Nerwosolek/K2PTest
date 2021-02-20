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
    private UIManager _uiManager;

    private void Awake()
    {
        _weapInd = (int)Weapons.Pistol;
        _currentWeapon = weapons[_weapInd];
        _uiManager = FindObjectOfType<UIManager>();
        if (_uiManager == null) Debug.LogWarning("Couldn't find UIManager in the scene.");
        else _uiManager.SetWeapon(_currentWeapon.Name);
        
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
            if (_uiManager != null) _uiManager.SetWeapon(_currentWeapon.Name);
        }
    }
}
