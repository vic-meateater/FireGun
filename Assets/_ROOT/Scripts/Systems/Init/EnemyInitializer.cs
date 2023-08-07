using System;
using System.Linq;
using System.Threading.Tasks;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using UnityEngine.Pool;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(EnemyInitializer))]
public sealed class EnemyInitializer : Initializer
{
    private GameData _gameData;
    private ObjectPool<GameObject> _enemiesPool;

    public override void OnAwake()
    {
        _gameData = World.Filter.With<GameData>().FirstOrDefault().GetComponent<GameData>();
        //var enemyHolderGO = Instantiate(_gameData.GameConfig.EnemiesHolder, Vector3.zero, Quaternion.identity);
        ref var enemyHolder = ref World.Filter.With<EnemiesHolderComponent>().FirstOrDefault()
            .GetComponent<EnemiesHolderComponent>();


        var enemyPF = enemyHolder.EnemiesPrefabs.FirstOrDefault();
        var position = _gameData.GameConfig.EnemySpawnPoint.FirstOrDefault().transform.position;
        var parent = enemyHolder.Parent;

        enemyHolder.ZombiePool = new ObjectPool<GameObject>(
            () => Instantiate(enemyPF, position, Quaternion.Euler(0f, 180f, 0f), parent),
            enemy => enemy.SetActive(true),
            enemy => enemy.SetActive(false),
            enemy => Destroy(enemy),
            true,
            10,
            10
        );
        _enemiesPool = enemyHolder.ZombiePool;
    }

    public override void Dispose()
    {
        // foreach (var pool in _enemiesPool)
        // {
        //     pool.Clear();
        //     pool.Dispose();
        // }

        _enemiesPool.Clear();
        _enemiesPool.Dispose();
    }
}