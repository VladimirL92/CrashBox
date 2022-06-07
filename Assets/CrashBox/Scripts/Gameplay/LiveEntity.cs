using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiveEntity : MonoBehaviour
{
    [SerializeField]
    private float _health;

    [SerializeField]
    private bool _collisionDamage;

    [SerializeField]
    private float _collisionDamageAcpect = 1f;

    [SerializeField]
    private bool _selfDestroy;

    public UnityEvent _onDead;
    public float Health => _health;

    private void Start()
    {
        CheckDead();
    }

    public void Damage(float points)
    {
        _health -= points;
        CheckDead();
    }

    private void CheckDead()
    {
        if (_health <= 0)
        {
            _onDead?.Invoke();

            if (_selfDestroy)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_collisionDamage)
        {
            Damage(collision.impulse.magnitude * _collisionDamageAcpect);
        }
    }
}
