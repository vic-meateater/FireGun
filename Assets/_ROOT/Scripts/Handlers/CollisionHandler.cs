using UnityEngine;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Globals.ECS;
using Scellecs.Morpeh;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GlobalEventObject _collisionEvent;

    private void OnCollisionEnter(Collision other)
    {
        _collisionEvent.Publish(other.gameObject);
        //TODO: ���-�� �������� entity id 



        //World.Default.


        //var instanceID = gameObject.GetInstanceID();


        //var entity = World.Default.GetEntity(instanceID);
        //Debug.Log(entity);
        //entity.AddComponent<CollisionReactComponent>();
        
        
       
    }
    
    // private async UniTask InitializeAndDeactivateAsync()
    // {
    //     GameObject enemy = _enemiesPool.Get();
    //     await UniTask.Delay(TimeSpan.FromSeconds(0.1));
    //     enemy.SetActive(false);
    // }
}
