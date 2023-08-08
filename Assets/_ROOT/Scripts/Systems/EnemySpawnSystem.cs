using System;
using System.Threading.Tasks;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Random = UnityEngine.Random;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemySpawnSystem))]
public sealed class EnemySpawnSystem : UpdateSystem
{
    private const int ENEMIES_ON_LEVEL = 11;

    private GameData _gameData;
    private EnemiesHolderComponent _enemyHolder;
    private float _spawnInterval = 0.5f;
    private float _spawnTimer = 0f;

    public override void OnAwake()
    {
        _gameData = World.Filter.With<GameData>().FirstOrDefault().GetComponent<GameData>();
        _enemyHolder = World.Filter.With<EnemiesHolderComponent>().FirstOrDefault()
            .GetComponent<EnemiesHolderComponent>();
        _spawnTimer = _spawnInterval;
    }

    public override void OnUpdate(float deltaTime)
    {
        _spawnTimer -= deltaTime;
        if (_spawnTimer <= 0f)
        {
            _spawnTimer = _spawnInterval;
            _ = SpawnEnemiesAsync(ENEMIES_ON_LEVEL);
        }
    }

    private async Task SpawnEnemiesAsync(int poolSize)
    {
        if (_enemyHolder.ZombiePool.CountActive < poolSize)
        {
            GameObject enemy = _enemyHolder.ZombiePool.Get();
            enemy.transform.position = GetPosition();
            await Task.Delay(TimeSpan.FromSeconds(_spawnInterval));
        }
    }

    private Vector3 GetPosition()
    {
        foreach (var spawnPoint in _gameData.GameConfig.EnemySpawnPoint)
            return spawnPoint.transform.position + new Vector3(Random.Range(-2f, 3f), 0f, Random.Range(0, 20));

        return Vector3.zero;
    }
}