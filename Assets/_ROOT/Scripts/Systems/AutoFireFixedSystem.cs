using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Globals.Events;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AutoFireFixedSystem))]
public sealed class AutoFireFixedSystem : FixedUpdateSystem
{
    private Filter _weaponFilter;
    private WeaponComponent _weapon;

    public GlobalEventObject OnBulletCollisionReact;

    public override void OnAwake()
    {
        _weaponFilter = World.Filter.With<WeaponComponent>();
        OnBulletCollisionReact.Subscribe(OnReact);
    }



    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _weaponFilter)
        {
            ref var weapon = ref entity.GetComponent<WeaponComponent>();
            _weapon = weapon;
            
            if (CanShoot(weapon))
            {
                var bulletGO = weapon.bulletPool.Get();


                if (bulletGO != null)
                {
                    bulletGO.transform.position = weapon.BulletSpawnPoint.position;
                    
                    var bulletRigidbody = bulletGO.GetComponentInChildren<Rigidbody>();
                    
                    
                    //TODO: заменить скорость полета пули 4f
                    bulletRigidbody.velocity = weapon.BulletSpawnPoint.forward * 19f;

                    weapon.LastShotTime = Time.time;
                }
            }
        }
    }
    private void OnReact(IEnumerable<UnityEngine.Object> obj)
    {
        _weapon.bulletPool.Release(obj.FirstOrDefault().GameObject());
    }
    private bool CanShoot(WeaponComponent weapon)
    {
        return Time.time - weapon.LastShotTime >= weapon.FireRate;
    }
}