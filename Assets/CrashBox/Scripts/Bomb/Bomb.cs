using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float _delayExplode = 0;

    [SerializeField]
    [Range(1, 20)]
    private int _steps = 1;

    [SerializeField]
    private float _maxDistance = 1;

    [SerializeField]
    private float _minForce = 0;

    [SerializeField]
    private float _maxForce = 1000;

    public void Explode()
    {
        StartCoroutine(ExplodeAsync());
    }

    private IEnumerator ExplodeAsync()
    {
        yield return new WaitForSeconds(_delayExplode);

        var origin = (Vector2) transform.position;

        for (var i = 1; i <= _steps; ++i)
        {
            var explodeDistance = i / (float)_steps * _maxDistance;
            var colliders = Physics2D.OverlapCircleAll(origin, explodeDistance);

            foreach (var collider in colliders)
            {
                var body = collider.attachedRigidbody;
                if (body)
                {
                    var point = collider.OverlapPoint(origin) ?
                        (Vector2)collider.bounds.center : 
                        collider.ClosestPoint(origin);

                    var distance = Vector2.Distance(point, origin);
                    var direction = (point - origin).normalized;
                    var force = Mathf.Lerp(_minForce, _maxForce, 1 - distance / _maxDistance);

                    body.AddForceAtPosition(force * direction, point);
                    Debug.Log($"Explode contact => name:{body.name}, force:{force}, distance: {distance}");

                    var liveEntity = body.GetComponentInParent<LiveEntity>();
                    if (liveEntity)
                    {
                        liveEntity.Damage(force);
                    }
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _maxDistance);
    }
}
