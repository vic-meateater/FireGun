using System.Collections.Generic;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Globals.Variables;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;


[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AmmoManagerSystem))]
public sealed class AmmoManagerSystem : UpdateSystem
{
    public GlobalVariableInt GIntCurrentBulletCount;
    public GlobalEventBool CanFire;
    public GlobalEvent GENotEnoughAmmoReact;

    
    public override void OnAwake()
    {
        Debug.Log("Loading ammo manager");
        GENotEnoughAmmoReact.Subscribe(OnGENotEnoughAmmo);
    }

        

    public override void OnUpdate(float deltaTime)
    {

    }
    
    private void OnGENotEnoughAmmo(IEnumerable<int> obj)
    {
        Debug.Log($"OnGENotEnoughAmmo - {obj}");
        GIntCurrentBulletCount.Value += 7;
    }
}