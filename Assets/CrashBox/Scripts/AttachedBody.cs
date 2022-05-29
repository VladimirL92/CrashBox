using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedBody : MonoBehaviour
{
    [SerializeField]
    private bool _tieLife;
    
    [SerializeField]
    private bool _syncRotation = true;

    private Transform _attachedRigidbody;
    private Vector3 _positionOffset;
    private Quaternion _rotationOffset;
    private bool _isAttached;

    private void Start()
    {
        var collider = Physics2D.OverlapPoint(transform.position);
        if (collider != null && collider.attachedRigidbody)
        {
            _isAttached = true;
            _attachedRigidbody = collider.attachedRigidbody.transform;
            _positionOffset = _attachedRigidbody.InverseTransformPoint(transform.position);
            _rotationOffset = transform.rotation * Quaternion.Inverse(_attachedRigidbody.rotation);
        }
    }

    private void Update()
    {
        if (_attachedRigidbody)
        {
            transform.position = _attachedRigidbody.TransformPoint(_positionOffset);

            if (_syncRotation)
            {
                transform.rotation = _rotationOffset * _attachedRigidbody.rotation;
            }
        }
        else if (_tieLife && _isAttached)
        {
            Destroy(gameObject);
        }
    }
}
