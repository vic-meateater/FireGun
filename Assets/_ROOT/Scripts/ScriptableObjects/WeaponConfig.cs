using System.Collections.Generic;
using _ROOT.Scripts.Handlers;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponConfig), menuName = "FireGun/Config/" + nameof(WeaponConfig))]
public class WeaponConfig : ScriptableObject
{
    [field: SerializeField] public List<BulletInfo> Bullets { get; private set; }
}

internal enum Weapons
{
    Gun,
    Rifle,
    Shotgun
}


