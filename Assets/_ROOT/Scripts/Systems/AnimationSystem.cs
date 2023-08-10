using System;
using _ROOT.Scripts.Helpers;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(AnimationSystem))]
public sealed class AnimationSystem : UpdateSystem
{
    private Filter _states;
    private int _moveAnimation;    

    public override void OnAwake()
    {
        _states = World.Filter.With<StateComponent>().With<AnimatorComponent>();
        _moveAnimation = Animator.StringToHash("Walk");
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in _states)
        {
            ref var state = ref entity.GetComponent<StateComponent>();
            ref var animator = ref entity.GetComponent<AnimatorComponent>();

            switch (state.CurrenState)
            {
                case EntityStates.Idle:
                    break;
                case EntityStates.Walk:
                    animator.Animator.SetTrigger("Walk");
                    break;
                case EntityStates.Attack:
                    break;
                case EntityStates.Damaged:
                    break;
                case EntityStates.Dead:
                    //Debug.Log("Animation Dead HERE!");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}