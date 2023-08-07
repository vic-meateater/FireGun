using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh.Providers;
using Unity.VisualScripting;

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
        if(obj == null) return;
        
        var z = obj.FirstOrDefault().GetComponent<UniversalProvider>().Entity;
        var x = obj.FirstOrDefault().GetComponent<Transform>();
        z.Dispose();
        Destroy(x.gameObject);
    }

    public override void OnUpdate(float deltaTime)
    {
        if (objectGlobalEventReact)
        {
            //Debug.Log("objectGlobalEventReact");
        }
    }
}