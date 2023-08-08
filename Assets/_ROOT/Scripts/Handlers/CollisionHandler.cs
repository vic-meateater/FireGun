using UnityEngine;
using Scellecs.Morpeh.Globals.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GlobalEventObject _collisionEvent;
    [SerializeField] private GlobalEventObject _bulletCollisionEvent;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<EnemyDataProvider>(out var enemy))
            _collisionEvent.Publish(enemy);

        _bulletCollisionEvent.Publish(gameObject);
    }
}