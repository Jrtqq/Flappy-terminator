using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private List<GameObject> _enemies = new();
    private float _spawnCooldown = 3;
    private float _time = 0;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _enemies.Add(transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _spawnCooldown)
        {
            _time = 0;
            TrySpawn();
        }
    }

    public void ReturnToPool(GameObject enemy)
    {
        _enemies.Add(enemy);
    }

    private void TrySpawn()
    {
        if (_enemies.Count > 0)
        {
            GameObject enemy = _enemies[Random.Range(0, _enemies.Count - 1)];
            enemy.SetActive(true);
            _enemies.Remove(enemy);
        }
    }
}
