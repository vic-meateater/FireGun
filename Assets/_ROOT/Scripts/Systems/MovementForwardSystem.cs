using _ROOT.Scripts.Helpers;
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
    private Vector3 _direction;
    private Filter _filter;

    public override void OnAwake()
    {
        _filter = World.Filter.With<MovableComponent>().With<StateComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _filter)
        {
            ref var movableComponent = ref entity.GetComponent<MovableComponent>();
            ref var state = ref entity.GetComponent<StateComponent>();
            state.CurrenState = EntityStates.Walk;
            _movementSpeed = movableComponent.MovementSpeed;
            _transform = movableComponent.Transform;
            _direction = movableComponent.Direction;
            MoveForward(_transform, _direction, _movementSpeed, deltaTime);
        }
    }

    private void MoveForward(Transform transform, Vector3 direction, float movementSpeed, float deltaTime)
    {
        transform.Translate(direction * movementSpeed * deltaTime, Space.World);
    }
}