using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Globals.Variables;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Serialization;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AmmoManagerSystem))]
public sealed class AmmoManagerSystem : UpdateSystem
{
    public GlobalVariableInt GlobalIntCurrentBulletCount;
    public GlobalEventBool CanFire;

    
    public override void OnAwake()
    {
        Debug.Log("Loading ammo manager");
    }

    public override void OnUpdate(float deltaTime)
    {
        //todo: не работает 
            var canShoot = GlobalIntCurrentBulletCount.Value > 0;
            CanFire.Publish(canShoot);
    }
}