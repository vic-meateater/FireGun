using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(HealthSystem))]
public sealed class HealthSystem : UpdateSystem 
{
    private Filter _filter;

    public override void OnAwake()
    {
        _filter = World.Filter.With<HealthComponent>();
    }

    public override void OnUpdate(float deltaTime) 
    {
        foreach (var entiity in _filter) 
        {
            ref var healthComponent = ref entiity.GetComponent<HealthComponent>();
            Debug.Log(healthComponent.healthPoints);
        }
    }
}