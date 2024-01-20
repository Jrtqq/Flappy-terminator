using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private List<EnemyController> _enemies = new();
    private float _spawnCooldown = 3;
    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _spawnCooldown)
        {
            _time = 0;
            TrySpawn();
        }
    }

    public void ReturnToPool(EnemyController enemy)
    {
        _enemies.Add(enemy);
    }

    private void TrySpawn()
    {
        if (_enemies.Count > 0)
        {
            EnemyController enemy = _enemies[Random.Range(0, _enemies.Count - 1)];
            enemy.Enable();
            _enemies.Remove(enemy);
        }
    }
}
