using UnityEngine;

namespace Client.Scriptable_Objects
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "FireGun/Config/" + nameof(GameConfig))]
    public class GameConfig: ScriptableObject
    {
        [field: SerializeField] public GameObject SpawnPoint { get; private set; }
    }
}