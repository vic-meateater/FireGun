using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using System.Collections.Generic;
using System;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionSystem))]
public sealed class CollisionSystem : UpdateSystem
{
    private Filter _bulletsFilter;
    public GlobalEventObject objectGlobalEventReact;

    public override void OnAwake()
    {
        _bulletsFilter = World.Filter.With<CollisionComponent>().With<BulletComponent>();
        objectGlobalEventReact.Subscribe(OnGlobalEventReact);
            
    }

    private void OnGlobalEventReact(IEnumerable<UnityEngine.Object> obj)
    {
        foreach(var o in obj)
        {
            Debug.Log(o.GetInstanceID());
        }
    }


    public override void OnUpdate(float deltaTime)
    {
        if (objectGlobalEventReact)
        {
            Debug.Log("objectGlobalEventReact");
        }
    }
}