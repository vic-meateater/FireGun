using UnityEngine;
using Scellecs.Morpeh.Globals.Events;
using Scellecs.Morpeh.Globals.ECS;
using Scellecs.Morpeh;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GlobalEventObject _collisionEvent;
    public GlobalEventComponent<WeaponComponent> _weaponComponent;

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
}
