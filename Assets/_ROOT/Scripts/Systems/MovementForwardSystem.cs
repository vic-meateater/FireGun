using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MovementForwardSystem))]
public sealed class MovementForwardSystem : UpdateSystem
{
    private float _movementSpeed;
    private Transform _transform;
    private Filter _filter;
    
    public override void OnAwake()
    {
        Debug.Log("Movement Forward System OnAwake");
        _filter = World.Filter.With<MovableComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _filter)
        {
            ref var movableComponent = ref entity.GetComponent<MovableComponent>();

            _movementSpeed = movableComponent.MovementSpeed;
            _transform = movableComponent.Transform;
        }
        MoveForward(_transform, _movementSpeed, deltaTime);
    }

    private void MoveForward(Transform transform, float movementSpeed, float deltaTime)
    {
        Vector3 forwardDirection = Vector3.forward;
        transform.Translate(forwardDirection * _movementSpeed * deltaTime, Space.World);
    }
}