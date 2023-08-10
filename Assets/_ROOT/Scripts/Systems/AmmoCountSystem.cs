using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Globals.Variables;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AmmoCountSystem))]
public sealed class AmmoCountSystem : UpdateSystem
{
    public GlobalVariableInt GlobalPlayerCurrentAmmoCount;
    public GlobalEventBool CanFireBoolGlobalEvent;
    public Filter _weaponComponentFilter;
    
    public override void OnAwake()
    {
        _weaponComponentFilter = World.Filter.With<WeaponComponent>().With<PlayerData>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _weaponComponentFilter)
        {
            ref var weapon = ref entity.GetComponent<WeaponComponent>();
            var canShoot = weapon.BulletAmount >= GlobalPlayerCurrentAmmoCount.Value;
                //todo: пофиксить
            if (canShoot)
            {
                CanFireBoolGlobalEvent.Publish(canShoot);
            }
            else
            {
                Debug.Log("Need reload");
            }

        }
    }
}