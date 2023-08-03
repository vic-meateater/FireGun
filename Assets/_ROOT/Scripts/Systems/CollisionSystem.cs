using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionSystem))]
public sealed class CollisionSystem : UpdateSystem
{
    private Filter _bulletsFilter;
    private HashSet<BulletComponent> _bullets;
    public GlobalEvent globalEvent;

    public override void OnAwake()
    {
        _bulletsFilter = World.Filter.With<CollisionComponent>().With<BulletComponent>();
        globalEvent = CreateInstance<GlobalEvent>();
        globalEvent.Subscribe(OnGlobalEventPublished);
    }

    private void OnGlobalEventPublished(IEnumerable<int> obj)
    {
        Debug.Log("OnGlobalEventPublished");
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var collisionEntity in _bulletsFilter)
        {
            ref var bullet = ref collisionEntity.GetComponent<CollisionComponent>();
            if (globalEvent)
            {
                //TODO: посомтреть flappy bird
                Debug.Log("GlobalEvent is published");
            }
            
        }
    }
}