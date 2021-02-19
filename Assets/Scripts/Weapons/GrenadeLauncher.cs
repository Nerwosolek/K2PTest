using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : AbstractWeapon
{
    [SerializeField]
    private float _power;
    public override void Shoot(Vector3 fromPosition, Vector3 atPosition)
    {
        Debug.Log(Physics.gravity);
        Debug.Log(fromPosition.y);
        GameObject grenade = Instantiate(Bullet, fromPosition, Quaternion.identity);
        var rb = grenade.GetComponent<Rigidbody>();
        var dir = (atPosition - fromPosition);
        dir.y = 0;
        var dist = dir.magnitude;
        dir.Normalize();
        //float vp = Mathf.Sqrt(Mathf.Abs(Physics.gravity.y) * dist / 2);
        float vp = dist * Mathf.Abs(Physics.gravity.y) / Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * (dist + fromPosition.y));
        dir *= vp;
        dir.y = vp;
        rb.AddForce(dir, ForceMode.Impulse);
    }
}
