using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.Serialization;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AnimToRagdollSystem))]
public sealed class AnimToRagdollSystem : UpdateSystem
{
    private Filter _filter;
    
    public GlobalEventObject AnimToRagdollReact;
    public override void OnAwake()
    {
    //    _filter = World.Filter.With<RagdollComponent>();
        AnimToRagdollReact.Subscribe(OnAnimToRagdoll);
    }

    private void OnAnimToRagdoll(IEnumerable<Object> obj)
    {
        var rd = obj.FirstOrDefault().GameObject();
        var x = rd.GetComponent<RagdollComponent>();
        //Debug.Log(rd.Bones.Length);
        foreach (var o in obj)
        {
            //todo: получить объект и компонент
            //var ragdoll = World.Filter.GetEntity(7);
            //Debug.Log($"Shoot React Bones Count - {ragdoll.Bones.Length}");
        }
    }

    public override void OnUpdate(float deltaTime)
    {
        _filter = World.Filter.With<RagdollComponent>().With<AnimToRagdollTagComponent>();
        
        foreach (var entity in _filter)
        {
            ref var ragdoll = ref entity.GetComponent<RagdollComponent>();
            InitRagdoll(ref ragdoll);
        }
    }
    
    private void InitRagdoll(ref RagdollComponent ragdoll)
    {
        if (ragdoll.RagdollRoot != null)
        {
            ragdoll.Bones = ragdoll.RagdollRoot.GetComponentsInChildren<Rigidbody>();
            foreach (var bone in ragdoll.Bones)
            {
                bone.isKinematic = false;
            }
            ragdoll.Animator.enabled = false;
            ragdoll.Collider.enabled = false;
        }
    }
}