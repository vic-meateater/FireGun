using Client.Scriptable_Objects;
using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[System.Serializable]
[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public struct GameData : IComponent
{
    [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
    [field: SerializeField] public GameConfig GameConfig { get; private set; }
    [field: SerializeField] public WeaponConfig WeaponConfig { get; private set; }
}