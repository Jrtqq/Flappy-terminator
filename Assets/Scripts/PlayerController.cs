using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private float _jumpForce = 7f;
    private Rigidbody2D _rigidbody;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private float _rotationSpeed = 1.3f;

    private void Awake()
    {
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

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(0, _jumpForce);
        transform.rotation = _maxRotation;
    }
}
