using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Shooter
{
    private string _targetTag = "Player";
    private float _time = 0;
    private float _cooldown = 2;

    private void Update()
    {
        _time += Time.deltaTime;

        if ( _time >= _cooldown)
        {
            _time = 0;
            _pool.Get();
        }
    }

    protected override Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bullet.Init(_pool, _targetTag);
        bullet.SetDirection(-transform.right);

        return bullet;
    }

    protected override void GetBullet(Bullet bullet)
    {
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
    }
}
