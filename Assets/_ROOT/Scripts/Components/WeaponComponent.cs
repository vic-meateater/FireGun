using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Pool;


[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct WeaponComponent : IComponent
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public ObjectPool<GameObject> bulletPool;
    public int BulletAmount;
    public float WeaponMoveSpeed;
    public float FireRate;
    public float LastShotTime;
    public int BulletPerShootCount;
}