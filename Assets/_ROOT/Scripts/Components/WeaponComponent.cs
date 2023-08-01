using System.Collections.Generic;
using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct WeaponComponent : IComponent
{
    public Transform BluuletSpawnPoint;
    public List<BulletComponent> Clips;
    public int BulletAmount;
}