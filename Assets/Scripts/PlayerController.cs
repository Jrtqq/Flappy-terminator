using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]

public class PlayerController : MonoBehaviour
{
    private readonly string _playerTag = "Player";

    public UnityAction Died;

    private float _jumpForce = 7f;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private float _rotationSpeed = 1.3f;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _minRotation = Quaternion.Euler(0, 0, -60);
        _maxRotation = Quaternion.Euler(0, 0, 50);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Bound _))
        {
            Died?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) && bullet.TargetTag == _playerTag)
        {
            Died?.Invoke();
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(0, _jumpForce);
        transform.rotation = _maxRotation;
    }
}
