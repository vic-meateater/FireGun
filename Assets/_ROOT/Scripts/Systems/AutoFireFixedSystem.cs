using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AutoFireFixedSystem))]
public sealed class AutoFireFixedSystem : FixedUpdateSystem
{
    private Filter _weaponFilter;
    private Filter _bulletFilter;
    private Transform _bulletSpawnPoint;
    
    public override void OnAwake()
    {
        _weaponFilter = World.Filter.With<WeaponComponent>();
        _bulletFilter = World.Filter.With<BulletComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _weaponFilter)
        {
            ref var weapon = ref entity.GetComponent<WeaponComponent>();
            _bulletSpawnPoint = weapon.BluuletSpawnPoint;
            
            foreach (var bulletEntity in _bulletFilter)
            {
                ref var bullet = ref bulletEntity.GetComponent<BulletComponent>();
                var bulletGO = Instantiate(bullet.Prefab, _bulletSpawnPoint.position, Quaternion.identity);

                var bulletRB = bulletGO.GetComponentInChildren<Rigidbody>();
                //bulletRB.velocity = bulletGO.transform.position * 3f;
            }
        }

    }
}