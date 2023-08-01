using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct WeaponHolderComponent : IComponent
{
    public GameObject Prefab;
    public Transform Transform;
    public Transform BulletSpawnPosition;
    public float MoveSpeed;
    public float FireRate;
    public Camera Camera;
}