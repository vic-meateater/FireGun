using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Serialization;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct RagdollComponent : IComponent
{
    public Rigidbody[] Bones;
    public GameObject RagdollRoot;
    public Animator Animator;
    public Collider Collider;
}