using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using _ROOT.Scripts.Helpers;
using Unity.VisualScripting;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CollisionSystem))]
public sealed class CollisionSystem : UpdateSystem
{
    //todo: подчистить
    private Filter _bulletsFilter;
    public GlobalEventObject objectGlobalEventReact;
    public GlobalEventObject AnimToRagdollEvent;

    public override void OnAwake()
    {
        _bulletsFilter = World.Filter.With<CollisionComponent>().With<BulletComponent>();
        objectGlobalEventReact.Subscribe(OnGlobalEventReact);
    }

    private void OnGlobalEventReact(IEnumerable<UnityEngine.Object> obj)
    {
        var rd = obj.FirstOrDefault().GetComponent<RagdollProvider>().Entity;
        if(rd.Has<MovableComponent>())    
            rd.RemoveComponent<MovableComponent>();
        
        if (rd != null && !rd.Has<AnimToRagdollTagComponent>())
            rd.AddComponent<AnimToRagdollTagComponent>();
        if (rd.Has<StateComponent>())
            rd.GetComponent<StateComponent>().CurrenState = EntityStates.Dead;



        //AnimToRagdollEvent.Publish(rd.GetComponent<RagdollComponent>());

        //var x = obj.FirstOrDefault().GetComponent<Transform>();
        //z.Dispose();
        //Destroy(x.gameObject);
    }

    public override void OnUpdate(float deltaTime)
    {
        if (objectGlobalEventReact)
        {
            //Debug.Log("objectGlobalEventReact");
        }
    }
}