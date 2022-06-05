using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(LiveEntity))]
public class BlockView : MonoBehaviour
{
    [SerializeField]
    private Color DeadColor = Color.black;

    private SpriteRenderer _spriteRenderer;
    private LiveEntity _liveEntity;

    private float _defaultHealth;
    private Color _defaultColor;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _liveEntity = GetComponent<LiveEntity>();

        _defaultColor = _spriteRenderer.color;
        _defaultHealth = _liveEntity.Health;
    }

    private void Update()
    {
        var t =  _liveEntity.Health / _defaultHealth;
        var color = Color.Lerp(DeadColor, _defaultColor, t);
        _spriteRenderer.color = color;
    }
}
