using UnityEngine;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Globals.ECS;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GlobalEventObject _collisionEvent;
    public GlobalEventComponent<WeaponComponent> _weaponComponent;

    private void OnCollisionEnter(Collision other)
    {
        
        //todo: не работает проверка
        if(other.gameObject.TryGetComponent<EnemyDataComponent>(out var enemyData));
            _collisionEvent.Publish(enemyData.Transform.gameObject);
    }
}
