using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public float Speed { get; internal set; }
    public float Range { get; internal set; }
    [SerializeField]
    private float _dmgModifier;
    private float _distanceTravelled;

    void FixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
        _distanceTravelled += Speed * Time.fixedDeltaTime;
        if (_distanceTravelled > Range) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HPManager>().TakeDamage(Speed * _dmgModifier);
        }
    }
}
