using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Variables;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Pool;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(WeaponHolderInitializer))]
public sealed class WeaponHolderInitializer : Initializer
{
    private GameObject _weaponGO;
    private Filter _weaponHolderFilter;
    private Filter _weaponFilter;
    private GameData _gameData;
    public GlobalVariableInt GlobalPlayerCurrentAmmoCount;

    public override void OnAwake()
    {
        _weaponHolderFilter = World.Filter.With<WeaponHolderComponent>();
        _weaponFilter = World.Filter.With<WeaponComponent>();

        foreach (var entityHolder in _weaponHolderFilter)
        {
            ref var weaponHolder = ref entityHolder.GetComponent<WeaponHolderComponent>();
            var weaponPF = weaponHolder.WeaponPrefab;
            _weaponGO = Instantiate(weaponPF, weaponHolder.Transform.position, Quaternion.identity,
                weaponHolder.Transform);
        }

        foreach (var entity in _weaponFilter)
        {
            ref var weapon = ref entity.GetComponent<WeaponComponent>();
            GlobalPlayerCurrentAmmoCount.Value = weapon.BulletAmount;
        }
    }

    public override void Dispose()
    {
        Destroy(_weaponGO);
    }
}