using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    private string _targetTag = "Enemy";
    private float _time = 1;
    private float _cooldown = 1;

    private void Update()
    {
        _time += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _time >= _cooldown)
        {
            _time = 0;
            _pool.Get();
        }
    }

    protected override Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bullet.Init(_pool, _targetTag);
        bullet.SetDirection(transform.right);

        bullet.SetInPool();
        return bullet;
    }

    protected override void GetBullet(Bullet bullet)
    {
        bullet.transform.position = transform.position;
        bullet.SetDirection(transform.right);

        bullet.SetInPool();
        bullet.gameObject.SetActive(true);
    }
}
