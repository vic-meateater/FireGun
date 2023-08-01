using System;
using UnityEngine;

namespace _ROOT.Scripts.Handlers
{
    [Serializable]
    public struct BulletInfo
    {
        public BulletsType bulletType;
        public GameObject bulletPrefab;
    }
}

public enum BulletsType
{
    Gun,
    Rifle,
    Shotgun
}