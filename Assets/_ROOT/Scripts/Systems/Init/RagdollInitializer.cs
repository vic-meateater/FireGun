using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(RagdollInitializer))]
public sealed class RagdollInitializer : Initializer
{
    private Filter _filter;

    public override void OnAwake()
    {
        _filter = World.Filter.With<RagdollComponent>();
        foreach (var e in _filter)
        {
            ref var ragdoll = ref e.GetComponent<RagdollComponent>();
            InitRagdoll(ragdoll);
        }
    }

    private void InitRagdoll(RagdollComponent ragdoll)
    {
        if (ragdoll.RagdollRoot != null)
            ragdoll.Bones = ragdoll.RagdollRoot.GetComponentsInChildren<Rigidbody>();
    }

    public override void Dispose()
    {
    }
}