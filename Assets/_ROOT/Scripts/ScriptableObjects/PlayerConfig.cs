using UnityEngine;

namespace Client.Scriptable_Objects
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "FireGun/Config/" + nameof(PlayerConfig))]
    public class PlayerConfig: ScriptableObject
    {
        [field: SerializeField] public PlayerData PlayerData { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}