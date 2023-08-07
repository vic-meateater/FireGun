using System.Collections.Generic;
using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UnityEngine.Pool;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct EnemiesHolderComponent : IComponent
{
    public List<GameObject> EnemiesPrefabs;  
    public ObjectPool<GameObject> ZombiePool;
    public Transform Parent;
}