using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(WeaponInitializer))]
public sealed class WeaponInitializer : Initializer
{
    private GameObject _weaponGO;
    private Filter _filter;

    public override void OnAwake()
    {
        _filter = World.Filter.With<WeaponComponent>();
        foreach (var entity in _filter)
        {
            ref var weaponHolder = ref entity.GetComponent<WeaponComponent>();
            _weaponGO = Instantiate(weaponHolder.Prefab, weaponHolder.Transform.position, Quaternion.identity,
                weaponHolder.Transform);
        }
    }

    public override void Dispose()
    {
        Destroy(_weaponGO);
    }
}