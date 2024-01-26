using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;

    protected ObjectPool<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(CreateBullet, GetBullet, ReleaseBullet, DestroyBullet);
    }

    protected void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    protected void DestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    protected abstract Bullet CreateBullet();
    protected abstract void GetBullet(Bullet bullet);
}
