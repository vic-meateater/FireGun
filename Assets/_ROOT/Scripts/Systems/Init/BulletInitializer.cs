using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Pool;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(BulletInitializer))]
public sealed class BulletInitializer : Initializer
{
    private Filter _weaponFilter;
    
    public override void OnAwake()
    {
        _weaponFilter = World.Filter.With<WeaponComponent>();
        foreach (var weaponEntity in _weaponFilter)
        {
            ref var weapon = ref weaponEntity.GetComponent<WeaponComponent>();
            var bulletPF = weapon.BulletPrefab;
            var bulletPosition = weapon.BulletSpawnPoint.position;
            weapon.bulletPool = new ObjectPool<GameObject>
            (
                () => Instantiate(bulletPF, bulletPosition, Quaternion.Euler(90f,0f,0f)),
                bullet => bullet.SetActive(true),
                bullet => bullet.SetActive(false)
            );
        }
    }

    public override void Dispose()
    {
        
    }
}