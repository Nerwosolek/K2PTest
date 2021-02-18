using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    [Range(0.1f, 10f)]
    private float _minSpawnInterval = 1f;
    [SerializeField]
    [Range(0.1f, 10f)]
    private float _maxSpawnInterval = 2f;
    [SerializeField]
    private Transform[] _spawnPoints;
    private Transform _playerTransform;
    private PlayerStats _pStats;
    private readonly float _spawnHeight = 0.5f;
    [SerializeField]
    private bool _spawningEnabled;
    private void Awake()
    {
        if (_enemyPrefab == null) Debug.LogWarning("Please drop enemy prefab to enable spawning");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) Debug.LogWarning("Couldn't find object tagged \"Player\" in the scene.");
        else
        {
            _playerTransform = player.transform;
            _pStats = player.GetComponent<PlayerStats>();
        }
        if (_spawnPoints == null || _spawnPoints.Length == 0) Debug.LogWarning("There is no spawn point defined.");
        if (_maxSpawnInterval < _minSpawnInterval) _maxSpawnInterval = _minSpawnInterval;
    }

    private void Start()
    {
        StartCoroutine(nameof(SpawningRoutine));
    }

    private IEnumerator SpawningRoutine()
    {
        while (true)
        {
            float interval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
            yield return new WaitForSeconds(interval);
            if (_spawningEnabled) Spawn();
        }
    }

    private void Spawn()
    {
        int spInd = Random.Range(0, _spawnPoints.Length);
        var sp = _spawnPoints[spInd];
        if (sp != null)
        {
            GameObject enemy = Instantiate(_enemyPrefab, new Vector3(sp.position.x, _spawnHeight, sp.position.z), Quaternion.identity);
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            enemyComponent.SetTarget(_playerTransform);
            enemyComponent.AddOnEnemyDealsDamage(_pStats.TakeDamage);
        }
    }
}
