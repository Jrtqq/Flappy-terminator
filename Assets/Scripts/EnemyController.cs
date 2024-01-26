using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AppearanceAnimation), typeof(Collider2D), typeof(SpriteRenderer))]
[RequireComponent(typeof(EnemyShooter))]

public class EnemyController : MonoBehaviour
{
    public UnityEvent Killed;

    private EnemyPool _pool;
    private AppearanceAnimation _animator;
    private Collider2D _collider;
    private SpriteRenderer _renderer;
    private EnemyShooter _shooter;

    public bool IsActive { get; private set; }

    private void Awake()
    {
        _pool = transform.parent.GetComponentInParent<EnemyPool>();
        _animator = GetComponent<AppearanceAnimation>();
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _shooter = GetComponent<EnemyShooter>();

        Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) && CompareTag(bullet.TargetTag))
        {
            Killed?.Invoke();
            Disable();
        }
    }

    public void Enable()
    {
        IsActive = true;
        _collider.enabled = true;
        _renderer.enabled = true;
        _shooter.enabled = true;

        StartCoroutine(_animator.Play());
    }

    public void Disable()
    {
        IsActive = false;
        _collider.enabled = false;
        _renderer.enabled = false;
        _shooter.enabled = false;

        _pool.ReturnToPool(this);
    }
}
