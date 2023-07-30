using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(PlayerInitializer))]
public sealed class PlayerInitializer : Initializer
{
    private Filter _gameDataFilter;
    private Filter _playerFilter;

    private Vector3 _position;
    private GameObject _playerPF;

    public override void OnAwake()
    {
        Debug.Log("Player Initializer");
        _gameDataFilter = World.Filter.With<GameData>();
        foreach (var gd in _gameDataFilter)
        {
            ref var data = ref gd.GetComponent<GameData>();
            _position = data.GameConfig.SpawnPoint.transform.position;

            var playerData = data.PlayerConfig.PlayerData;
            _playerPF = Instantiate(playerData.Prefab, _position, Quaternion.identity);

        }
    }

    public override void Dispose()
    {
        Destroy (_playerPF);
    }
}