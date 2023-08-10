using Scellecs.Morpeh;
using Scellecs.Morpeh.Globals.Variables;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UIButtonClickedSystem))]
public sealed class UIButtonClickedSystem : UpdateSystem
{
    private Filter buttonClickedFilter;


    public override void OnAwake()
    {
        buttonClickedFilter = World.Filter.With<UIStartButtonClickedEventComponent>();
    }

    public override void OnUpdate(float deltaTime)
    {
        foreach (var entity in buttonClickedFilter)
        {
            ref var buttonClickedEvent = ref entity.GetComponent<UIStartButtonClickedEventComponent>();
            string buttonName = buttonClickedEvent.ButtonName;
            Debug.Log("Button " + buttonName + " is clicked!");
            entity.RemoveComponent<UIStartButtonClickedEventComponent>();
        }
    }

    private void OnButtonClick(string obj)
    {
        Debug.Log("Button " + obj + " is clicked!");
    }
}