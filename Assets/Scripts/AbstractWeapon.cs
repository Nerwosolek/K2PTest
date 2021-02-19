using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject _bulletPrefab;
    public GameObject Bullet { get => _bulletPrefab; }
    public abstract void Shoot(Vector3 spawnPoint, Vector3 targetPosition);
}