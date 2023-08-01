using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct BulletInfo: IComponent
{
    public BulletsType bulletType;
    public GameObject bulletPrefab;
}


public enum BulletsType
{
    Gun,
    Rifle,
    Shotgun
}