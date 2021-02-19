using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : AbstractWeapon
{
    [SerializeField]
    float _speed;
    [SerializeField]
    float _range;
    public override void Shoot(Vector3 spawn, Vector3 target)
    {
        GameObject bullet = Instantiate(Bullet, spawn, Quaternion.LookRotation(target - spawn));
        var pistolBullet = bullet.GetComponent<PistolBullet>();
        pistolBullet.Speed = _speed;
        pistolBullet.Range = _range;
    }
}
