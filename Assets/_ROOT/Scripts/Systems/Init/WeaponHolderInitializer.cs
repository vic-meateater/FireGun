using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;


[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(WeaponHolderInitializer))]
public sealed class WeaponHolderInitializer : Initializer
{
    private GameObject _weaponGO;
    private Filter _weaponHolderFilter;
    private GameData _gameData;

    public override void OnAwake()
    {
        _weaponHolderFilter = World.Filter.With<WeaponHolderComponent>();

        foreach (var entityHolder in _weaponHolderFilter)
        {
            ref var weaponHolder = ref entityHolder.GetComponent<WeaponHolderComponent>();
            var weaponPF = weaponHolder.WeaponPrefab;
            _weaponGO = Instantiate(weaponPF, weaponHolder.Transform.position, Quaternion.identity,
                weaponHolder.Transform);
        }
    }

    public override void Dispose()
    {
        Destroy(_weaponGO);
    }
}