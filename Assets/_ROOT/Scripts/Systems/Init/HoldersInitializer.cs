using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(HoldersInitializer))]
public sealed class HoldersInitializer : Initializer
{
    private GameData _gameData;
    private GameObject _enemyHolderGO;

    public override void OnAwake()
    {
        _gameData = World.Filter.With<GameData>().FirstOrDefault().GetComponent<GameData>();
        _enemyHolderGO = Instantiate(_gameData.GameConfig.EnemiesHolder, Vector3.zero, Quaternion.identity);
    }

    public override void Dispose()
    {
        Destroy(_enemyHolderGO);
    }
}