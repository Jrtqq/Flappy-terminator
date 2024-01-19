using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private string _targetTag;
    private Vector3 _direction;
    private ObjectPool<Bullet> _pool;
    private float _speed = 5f;
    private float _lifetime = 10f;
    private float _time = 0;

    public string TargetTag => _targetTag;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _lifetime)
        {
            Disable();
        }

        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_targetTag))
        {
            Disable();
        }
    }

    private void Disable()
    {
        _time = 0;
        _pool.Release(this);
    }

    public void Init(ObjectPool<Bullet> pool, string targetTag)
    {
        _pool = pool;
        _targetTag = targetTag;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
