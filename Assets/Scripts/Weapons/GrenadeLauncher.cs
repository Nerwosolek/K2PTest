using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GrenadeLauncher : AbstractWeapon
{
    [Tooltip("ms between grenades launches.")]
    [SerializeField]
    private long _launchInterval;
    private float _g;
    private Stopwatch sw;
    private void Awake()
    {
        _g = Mathf.Abs(Physics.gravity.y);
        sw = new Stopwatch();
    }
    public override Weapons Name => Weapons.GrenadeLauncher;

    public override void Shoot(Vector3 fromPosition, Vector3 atPosition)
    {
        if (sw.ElapsedMilliseconds > _launchInterval || !sw.IsRunning)
        {
            GameObject grenade = Instantiate(Bullet, fromPosition, Quaternion.identity);
            var rb = grenade.GetComponent<Rigidbody>();
            var dir = (atPosition - fromPosition);
            dir.y = 0;
            var dist = dir.magnitude;
            dir.Normalize();
            float vp = dist * _g / Mathf.Sqrt(2 * _g * (dist + fromPosition.y));
            dir *= vp;
            dir.y = vp;
            rb.AddForce(dir, ForceMode.Impulse);

            sw.Restart();
        }
    }
}
