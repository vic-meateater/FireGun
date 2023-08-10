using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Variables;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Serialization;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UIAmmoCountLateSystem))]
public sealed class UIAmmoCountLateSystem : LateUpdateSystem
{
    public GlobalVariableInt GlobalIntCurrentBulletCount;
    public GlobalVariableInt GlobalIntTotalBulletCount;
    
    public Filter _weaponComponentFilter;
    private UIPlayerAmmoComponent _ui;
    
    public override void OnAwake()
    {
        _ui = World.Filter.With<UIPlayerAmmoComponent>().FirstOrDefault().GetComponent<UIPlayerAmmoComponent>();
        _weaponComponentFilter = World.Filter.With<WeaponComponent>().With<PlayerTagComponent>();
        foreach (var entity in _weaponComponentFilter)
        {
            ref var weapon = ref entity.GetComponent<WeaponComponent>();
            GlobalIntCurrentBulletCount.Value = weapon.BulletAmount;
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        _ui.UIPlayerCurrentAmmoCount.text = GlobalIntCurrentBulletCount.Value.ToString();
        _ui.UIPlayerTotalAmmoCount.text = GlobalIntTotalBulletCount.Value.ToString();
    }
}