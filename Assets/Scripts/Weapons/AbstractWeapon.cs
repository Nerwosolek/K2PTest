using UnityEngine;

public enum Weapons
{
    Pistol = 0,
    GrenadeLauncher = 1
}
public abstract class AbstractWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject _bulletPrefab;
    public GameObject Bullet { get => _bulletPrefab; }
    public abstract void Shoot(Vector3 spawnPoint, Vector3 targetPosition);
    public abstract Weapons Name { get; }
}