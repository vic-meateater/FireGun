using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;
using System.Collections.Generic;
using System;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AutoFireFixedSystem))]
public sealed class AutoFireFixedSystem : FixedUpdateSystem
{
    private Filter _weaponFilter;
    private Filter _collisionEntityFilter;
    private Filter _collisionBulletFilter;

    public GlobalEventObject OnBulletCollisionReact;

    public override void OnAwake()
    {
        _weaponFilter = World.Filter.With<WeaponComponent>();
        _collisionEntityFilter = World.Filter.With<CollisionReactComponent>();
        _collisionBulletFilter = World.Filter.With<CollisionReactComponent>().With<BulletComponent>();
        OnBulletCollisionReact.Subscribe(OnReact);
    }

    private void OnReact(IEnumerable<UnityEngine.Object> obj)
    {
        //Debug.Log("Реакция на пулю здеся");
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _weaponFilter)
        {
            ref var weapon = ref entity.GetComponent<WeaponComponent>();

            if (CanShoot(weapon))
            {
                var bulletGO = weapon.bulletPool.Get();


                if (bulletGO != null)
                {
                    bulletGO.transform.position = weapon.BulletSpawnPoint.position;

                    var bulletRigidbody = bulletGO.GetComponentInChildren<Rigidbody>();

                    //TODO: заменить скорость полета пули 4f
                    bulletRigidbody.velocity = weapon.BulletSpawnPoint.forward * 4f;

                    weapon.LastShotTime = Time.time;
                }
            }

            if (OnBulletCollisionReact)
            {
                // Debug.Log($"Всего коллизий - {_collisionBulletFilter}");
                // Debug.Log($"Буллет - {_collisionBulletFilter}");
                //TODO: обработка реакции на ивент
            }
        }
    }

    private bool CanShoot(WeaponComponent weapon)
    {
        return Time.time - weapon.LastShotTime >= weapon.FireRate;
    }
}