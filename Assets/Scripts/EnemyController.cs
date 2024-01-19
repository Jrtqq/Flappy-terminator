using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyController : MonoBehaviour
{
    private readonly string _triggerTag = "Appear";

    private EnemyPool _pool;
    private Animator _animator;
    private GameObject _thisEnemy; //Объект врага под пустышкой, чтобы анимация нормально работала

    private void Awake()
    {
        _thisEnemy = transform.parent.gameObject;

        _pool = transform.parent.GetComponentInParent<EnemyPool>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetTrigger(_triggerTag);
    }

    private void OnDisable()
    {
        _pool.ReturnToPool(_thisEnemy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) && CompareTag(bullet.TargetTag))
        {
            _thisEnemy.SetActive(false);
        }
    }
}
